try:
    __import__("pysqlite3")
    import sys
    sys.modules["sqlite3"] = sys.modules.pop("pysqlite3")
except ImportError:
    pass

import math
import re
import time
import xml.etree.ElementTree as ET
from dataclasses import dataclass
from pathlib import Path
from typing import Any, Dict, List, Optional, Tuple

import httpx
from langchain_community.embeddings import HuggingFaceEmbeddings
from langchain_community.vectorstores import Chroma

from app.config import CHROMA_DB_PATH


def _localname(tag: str) -> str:
    # Handles XML namespaces by returning the "local" part of the tag.
    return tag.rsplit("}", 1)[-1]


def _find_child_text(parent: ET.Element, local_tag: str) -> Optional[str]:
    for el in parent.iter():
        if _localname(el.tag) == local_tag:
            if el.text and el.text.strip():
                return el.text.strip()
    return None


def _find_all_texts(parent: ET.Element, local_tag: str) -> List[str]:
    out: List[str] = []
    for el in parent.iter():
        if _localname(el.tag) == local_tag:
            if el.text and el.text.strip():
                out.append(el.text.strip())
    return out


def _compute_relevance_score(query: str, title: str, abstract: str) -> float:
    # Dependency-free quick scoring: token overlap normalized to [0..1].
    query_tokens = {t for t in re.findall(r"\w+", query.lower()) if len(t) >= 3}
    if not query_tokens:
        return 0.0

    doc_text = f"{title} {abstract}".lower()
    hits = sum(1 for t in query_tokens if t in doc_text)
    return hits / max(len(query_tokens), 1)


@dataclass
class _PubMedArticle:
    title: str
    authors: List[str]
    abstract: str
    journal: str
    year: Optional[int]
    pmid: str


def _parse_pubmed_efetch_xml(xml_text: str) -> List[_PubMedArticle]:
    # PubMed XML has namespaces; we use local-name matching to stay robust.
    root = ET.fromstring(xml_text)
    articles: List[_PubMedArticle] = []

    for node in root.iter():
        if _localname(node.tag) != "PubmedArticle":
            continue

        medline_citation = None
        for child in node.iter():
            if _localname(child.tag) == "MedlineCitation":
                medline_citation = child
                break
        if medline_citation is None:
            continue

        article_node = None
        for child in medline_citation.iter():
            if _localname(child.tag) == "Article":
                article_node = child
                break
        if article_node is None:
            continue

        title = _find_child_text(article_node, "ArticleTitle") or ""
        abstract_parts = _find_all_texts(article_node, "AbstractText")
        abstract = " ".join(abstract_parts).strip()

        journal_title = _find_child_text(article_node, "JournalTitle") or ""

        # Authors
        authors: List[str] = []
        for author in article_node.iter():
            if _localname(author.tag) != "Author":
                continue
            last = _find_child_text(author, "LastName")
            fore = _find_child_text(author, "ForeName") or _find_child_text(author, "Initials")
            if last:
                if fore:
                    authors.append(f"{fore} {last}".strip())
                else:
                    authors.append(last)

        year_text = (
            _find_child_text(article_node, "Year")
            or _find_child_text(article_node, "MedlineDate")
            or _find_child_text(article_node, "PubDate")
        )
        year_val: Optional[int] = None
        if year_text:
            m = re.search(r"\b(19\d{2}|20\d{2})\b", year_text)
            if m:
                year_val = int(m.group(1))

        pmid = _find_child_text(medline_citation, "PMID") or ""
        if pmid:
            articles.append(
                _PubMedArticle(
                    title=title,
                    authors=authors,
                    abstract=abstract,
                    journal=journal_title,
                    year=year_val,
                    pmid=str(pmid),
                )
            )

    return articles


_EMBEDDINGS: Optional[HuggingFaceEmbeddings] = None
_CHROMA: Optional[Chroma] = None


class SearchAgent:
    """
    Search PubMed via NCBI E-utilities + local documents via Chroma.
    """

    def _get_chroma(self) -> Chroma:
        global _EMBEDDINGS, _CHROMA
        if _CHROMA is not None and _EMBEDDINGS is not None:
            return _CHROMA

        Path(CHROMA_DB_PATH).mkdir(parents=True, exist_ok=True)

        embeddings = HuggingFaceEmbeddings(model_name="sentence-transformers/all-MiniLM-L6-v2")
        # Persisted locally at CHROMA_DB_PATH
        vectorstore = Chroma(persist_directory=CHROMA_DB_PATH, embedding_function=embeddings)

        _EMBEDDINGS = embeddings
        _CHROMA = vectorstore
        return _CHROMA

    def search(self, query: str, max_pubmed_results: int = 10) -> List[Dict[str, Any]]:
        query = (query or "").strip()
        if not query:
            return []

        pubmed_results: List[Dict[str, Any]] = self._search_pubmed(query, max_pubmed_results)
        local_results: List[Dict[str, Any]] = self._search_chroma(query, k=5)

        merged: List[Dict[str, Any]] = []
        dedup: Dict[str, Dict[str, Any]] = {}

        for item in pubmed_results + local_results:
            key = str(item.get("pmid_or_doc_id") or "")
            if not key:
                continue

            existing = dedup.get(key)
            if existing is None or float(item.get("relevance_score") or 0.0) > float(existing.get("relevance_score") or 0.0):
                dedup[key] = item

        merged = list(dedup.values())
        merged.sort(key=lambda x: float(x.get("relevance_score") or 0.0), reverse=True)
        return merged

    def _search_pubmed(self, query: str, max_pubmed_results: int) -> List[Dict[str, Any]]:
        esearch_url = "https://eutils.ncbi.nlm.nih.gov/entrez/eutils/esearch.fcgi"
        efetch_url = "https://eutils.ncbi.nlm.nih.gov/entrez/eutils/efetch.fcgi"

        params = {
            "db": "pubmed",
            "term": query,
            "retmax": str(max_pubmed_results),
            "retmode": "json",
        }

        # Best-effort requests; avoid blocking too long.
        timeout = httpx.Timeout(15.0)
        with httpx.Client(timeout=timeout, follow_redirects=True) as client:
            r = client.get(esearch_url, params=params)
            r.raise_for_status()
            payload = r.json()
            ids: List[str] = payload.get("esearchresult", {}).get("idlist", []) or []

            if not ids:
                return []

            # NCBI allows comma-separated IDs.
            efetch_params = {
                "db": "pubmed",
                "id": ",".join(ids),
                "rettype": "abstract",
                "retmode": "xml",
            }
            xr = client.get(efetch_url, params=efetch_params)
            xr.raise_for_status()
            articles = _parse_pubmed_efetch_xml(xr.text)

        out: List[Dict[str, Any]] = []
        for a in articles:
            score = _compute_relevance_score(query, a.title, a.abstract)
            out.append(
                {
                    "title": a.title,
                    "authors": a.authors,
                    "abstract": a.abstract,
                    "source": "pubmed",
                    "year": a.year,
                    "pmid_or_doc_id": a.pmid,
                    "relevance_score": score,
                }
            )

        # Keep only top max_pubmed_results by score, even if efetch returns more.
        out.sort(key=lambda x: float(x.get("relevance_score") or 0.0), reverse=True)
        return out[: max_pubmed_results]

    def _search_chroma(self, query: str, k: int = 5) -> List[Dict[str, Any]]:
        vectorstore = self._get_chroma()

        try:
            pairs = vectorstore.similarity_search_with_relevance_scores(query, k=k)
            docs_and_scores: List[Tuple[Any, float]] = [(d, float(s)) for d, s in pairs]
        except Exception:
            # Fallback if method not available.
            docs = vectorstore.similarity_search(query, k=k)
            docs_and_scores = [(d, 0.0) for d in docs]

        out: List[Dict[str, Any]] = []
        for doc, score in docs_and_scores:
            md = getattr(doc, "metadata", {}) or {}
            doc_id = md.get("doc_id")
            if not doc_id:
                source_file = md.get("source_file") or ""
                page_number = md.get("page_number")
                chunk_index = md.get("chunk_index")
                doc_id = f"{source_file}:{page_number}:{chunk_index}"

            out.append(
                {
                    "title": str(md.get("source_file") or ""),
                    "authors": [],
                    "abstract": str(getattr(doc, "page_content", "") or "")[:2000],
                    "source": "local_docs",
                    "year": md.get("year"),
                    "pmid_or_doc_id": doc_id,
                    "relevance_score": score,
                }
            )

        return out

