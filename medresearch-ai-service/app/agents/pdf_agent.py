__import__("pysqlite3")
import sys

sys.modules["sqlite3"] = sys.modules.pop("pysqlite3")

from __future__ import annotations

import re
import tempfile
from pathlib import Path
from typing import Any, Dict, List, Optional, Sequence, Tuple
from uuid import uuid4

from fastapi import HTTPException
from langchain_community.chat_models import ChatOllama
from langchain_community.document_loaders import PyPDFLoader
from langchain_community.embeddings import HuggingFaceEmbeddings
from langchain_community.vectorstores import Chroma
from langchain_core.messages import HumanMessage, SystemMessage
from langchain_text_splitters import RecursiveCharacterTextSplitter

from app.config import CHROMA_DB_PATH, OLLAMA_BASE_URL

HIPAA_SYSTEM_PROMPT = """
You are a HIPAA-compliant medical research assistant for MedResearch Ninja.
STRICT RULES:
1. NEVER expose, repeat, or acknowledge PHI (names, DOB, SSN, phone, email, address, MRN)
2. NEVER generate fake realistic patient data
3. NEVER provide individual medical diagnoses
4. ALWAYS de-identify all examples using aggregate or statistical language
5. ALWAYS refer to individuals as 'the patient' or 'the subject'
6. If PHI is present in context or requested — REFUSE and explain why
7. If unsure whether something violates HIPAA — REFUSE
Focus only on research-level findings, methodologies, and aggregate outcomes.
"""


# Strict PHI patterns for generated outputs.
OUTPUT_STRICT_PHI_PATTERNS = {
    "SSN": re.compile(r"\b\d{3}-\d{2}-\d{4}\b"),
    "Email": re.compile(
        r"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b",
        re.I,
    ),
    "Phone": re.compile(r"\b\d{3}[-.\s]\d{3}[-.\s]\d{4}\b"),
}


# Strict PHI patterns for PDF ingestion chunks (no email; papers include author emails).
INGEST_STRICT_PHI_PATTERNS = {
    "SSN": re.compile(r"\b\d{3}-\d{2}-\d{4}\b"),
    "Phone": re.compile(r"\b\d{3}[-.\s]\d{3}[-.\s]\d{4}\b"),
}


def _contains_output_strict_phi(text: str) -> bool:
    for pattern in OUTPUT_STRICT_PHI_PATTERNS.values():
        if pattern.search(text):
            return True
    return False


def _contains_ingest_strict_phi(text: str) -> bool:
    for pattern in INGEST_STRICT_PHI_PATTERNS.values():
        if pattern.search(text):
            return True
    return False


def _normalize_chat_history(chat_history: Any) -> List[Tuple[str, str]]:
    """
    Accept a variety of client formats and convert to a list of (user, assistant) tuples.
    """
    if not chat_history:
        return []

    pairs: List[Tuple[str, str]] = []
    for item in chat_history:
        if isinstance(item, dict):
            q = item.get("question") or item.get("user") or item.get("prompt") or ""
            a = item.get("answer") or item.get("assistant") or item.get("response") or ""
            if q or a:
                pairs.append((str(q), str(a)))
        elif isinstance(item, (list, tuple)) and len(item) == 2:
            pairs.append((str(item[0]), str(item[1])))
    return pairs


class PDFAgent:
    """
    PDF ingestion and conversational Q&A over a session-specific Chroma collection.
    """

    def __init__(self) -> None:
        self._embeddings = HuggingFaceEmbeddings(model_name="sentence-transformers/all-MiniLM-L6-v2")

    def _session_collection_name(self, session_id: str) -> str:
        return f"session_{session_id}"

    def ingest_pdf(self, file_bytes: bytes, session_id: str) -> Dict[str, Any]:
        """
        Ingest PDF bytes into a session-specific Chroma collection.
        Session collections should be cleaned up after 24 hours (cleanup note).
        """
        if not session_id:
            session_id = str(uuid4())

        # Cleanup note: Implement TTL cleanup in the background/cron job.
        # This agent only writes session_{session_id}; deletion after 24h is expected operationally.
        collection_name = self._session_collection_name(session_id)

        with tempfile.NamedTemporaryFile(delete=False, suffix=".pdf") as tmp:
            tmp_path = Path(tmp.name)
            tmp.write(file_bytes)
            tmp.flush()

        page_count = 0
        chunk_count = 0

        try:
            loader = PyPDFLoader(str(tmp_path))
            pages = loader.load()  # one Document per page
            page_count = len(pages)
            total_text_chars = sum(len(getattr(page, "page_content", "") or "") for page in pages)

            if total_text_chars < 100:
                return {
                    "session_id": session_id,
                    "page_count": page_count,
                    "chunk_count": 0,
                    "status": "no_text",
                }

            splitter = RecursiveCharacterTextSplitter(chunk_size=500, chunk_overlap=50)
            chunks = splitter.split_documents(pages)
            total_chunks = len(chunks)
            if total_chunks == 0:
                return {
                    "session_id": session_id,
                    "page_count": page_count,
                    "chunk_count": 0,
                    "status": "no_text",
                }

            flagged_chunks = 0
            safe_chunks = []
            for chunk in chunks:
                chunk_text = getattr(chunk, "page_content", "") or ""
                if _contains_ingest_strict_phi(chunk_text):
                    flagged_chunks += 1
                    continue
                safe_chunks.append(chunk)

            # Reject only if strict PHI appears in more than half the chunks.
            if flagged_chunks > (total_chunks / 2):
                return {
                    "session_id": session_id,
                    "page_count": page_count,
                    "chunk_count": 0,
                    "status": "rejected_phi",
                }

            chunk_count = len(safe_chunks)

            vectorstore = Chroma(
                persist_directory=CHROMA_DB_PATH,
                collection_name=collection_name,
                embedding_function=self._embeddings,
            )
            if safe_chunks:
                vectorstore.add_documents(safe_chunks)
            vectorstore.persist()

            return {
                "session_id": session_id,
                "page_count": page_count,
                "chunk_count": chunk_count,
                "status": "stored",
            }
        finally:
            try:
                tmp_path.unlink(missing_ok=True)
            except Exception:
                pass

    def chat(self, question: str, session_id: str, chat_history: list) -> Dict[str, Any]:
        collection_name = self._session_collection_name(session_id)

        vectorstore = Chroma(
            persist_directory=CHROMA_DB_PATH,
            collection_name=collection_name,
            embedding_function=self._embeddings,
        )

        # Use retriever to gather relevant context.
        retriever = vectorstore.as_retriever(search_kwargs={"k": 5})
        docs = retriever.get_relevant_documents(question)

        context_parts: List[str] = []
        source_pages: List[int] = []
        for d in docs:
            md = getattr(d, "metadata", {}) or {}
            page_num = md.get("page_number", md.get("page", 0))
            try:
                source_pages.append(int(page_num))
            except Exception:
                source_pages.append(0)
            context_parts.append(getattr(d, "page_content", "") or "")

        source_pages = sorted({p for p in source_pages if p is not None})

        context_text = "\n\n---\n\n".join(context_parts)

        pairs = _normalize_chat_history(chat_history)
        chat_history_text = ""
        if pairs:
            chat_history_text = "\n".join([f"User: {q}\nAssistant: {a}" for q, a in pairs])

        # Build a lightweight "ConversationalRetrievalChain" (LangChain's class isn't available in this install)
        # with Ollama + the HIPAA system prompt.
        llm = ChatOllama(
            model="llama3.1:8b",
            temperature=0,
            base_url=OLLAMA_BASE_URL,
            timeout=120,
        )

        class ConversationalRetrievalChain:
            def __init__(self, llm_model: ChatOllama, system_prompt: str) -> None:
                self._llm = llm_model
                self._system_prompt = system_prompt

            def invoke(self, inputs: Dict[str, Any]) -> Dict[str, Any]:
                q = inputs["question"]
                history = inputs.get("chat_history_text", "")
                ctx = inputs.get("context_text", "")
                messages = [
                    SystemMessage(content=self._system_prompt),
                    HumanMessage(
                        content=(
                            "You will be given research context excerpts and a research question.\n\n"
                            f"Research question:\n{q}\n\n"
                            f"Conversation history:\n{history or '[none]'}\n\n"
                            f"Context excerpts:\n{ctx[:12000]}\n"
                        )
                    ),
                ]
                resp = self._llm.invoke(messages)
                ans = getattr(resp, "content", None) or str(resp)
                return {"answer": ans}

        chain = ConversationalRetrievalChain(llm_model=llm, system_prompt=HIPAA_SYSTEM_PROMPT)
        chain_out = chain.invoke(
            {"question": question, "chat_history_text": chat_history_text, "context_text": context_text}
        )
        answer = chain_out["answer"]

        # Strict-only PHI check on the generated output.
        if _contains_output_strict_phi(str(answer)):
            raise HTTPException(status_code=400, detail="PHI detected in generated answer")

        chat_history_updated = []
        # Preserve original format as much as possible.
        if chat_history:
            chat_history_updated = list(chat_history)

        # Always append a standard {question, answer} entry so the client can render.
        chat_history_updated.append({"question": question, "answer": answer})

        return {
            "answer": answer,
            "source_pages": source_pages,
            "chat_history_updated": chat_history_updated,
        }

