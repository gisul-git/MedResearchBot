from __future__ import annotations

import re
from typing import Any, Dict, List

from fastapi import HTTPException
from langchain_community.chat_models import ChatOllama
from langchain_core.messages import HumanMessage, SystemMessage

from app.agents.pdf_agent import HIPAA_SYSTEM_PROMPT
from app.config import OLLAMA_BASE_URL
from app.phi_scanner import redact_text


# Only block if the review contains patterns that are unambiguously PHI.
STRICT_PHI_PATTERNS = {
    "SSN": re.compile(r"\b\d{3}-\d{2}-\d{4}\b"),
    "Email": re.compile(
        r"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b",
        re.I,
    ),
    "Phone": re.compile(r"\b\d{3}[-.\s]\d{3}[-.\s]\d{4}\b"),
}


def _contains_strict_phi(text: str) -> bool:
    for pattern in STRICT_PHI_PATTERNS.values():
        if pattern.search(text):
            return True
    return False


class ReviewAgent:
    """
    Review agent that generates a structured literature review from paper abstracts.
    """

    def review(self, topic: str, papers: List[Dict[str, Any]]) -> Dict[str, Any]:
        llm = ChatOllama(model="llama3.1:8b", temperature=0, base_url=OLLAMA_BASE_URL)

        sanitized: List[Dict[str, Any]] = []
        # Limit prompt size/latency for UX and to avoid browser timeouts.
        for p in (papers or [])[:5]:
            abstract = str(p.get("abstract") or "")
            # De-identify paper data by redacting abstracts.
            redacted_abstract = redact_text(abstract)
            sanitized.append({**p, "abstract": redacted_abstract})

        paper_count = len(sanitized)

        abstracts_block = "\n\n".join(
            [
                f"Title: {str(p.get('title') or '')}\nJournal: {str(p.get('source') or '')}\nYear: {p.get('year')}\nPMID/Doc: {str(p.get('pmid_or_doc_id') or '')}\nAbstract: {str(p.get('abstract') or '')}"
                for p in sanitized
            ]
        )

        instruction = (
            "Write a structured literature review with exactly these sections:\n"
            "1. Introduction  2. Key Findings  3. Research Gaps  4. Conclusion  5. References\n"
            f"Topic: {topic}\n"
            f"Papers: {abstracts_block}"
        )

        messages = [
            SystemMessage(content=HIPAA_SYSTEM_PROMPT),
            HumanMessage(content=instruction),
        ]

        resp = llm.invoke(messages, timeout=120)
        review_text = getattr(resp, "content", None) or str(resp)

        if _contains_strict_phi(review_text):
            raise HTTPException(status_code=400, detail="PHI detected in generated review")

        return {"review_text": review_text, "paper_count": paper_count, "topic": topic}

    def _parse_sections(self, text: str) -> Dict[str, str]:
        """
        Best-effort section parser using exact headings.
        """
        headings = ["Introduction", "Key Findings", "Research Gaps", "Conclusion", "References"]
        # Normalize line endings.
        t = text.replace("\r\n", "\n").replace("\r", "\n")

        # Build a regex that captures content between headings.
        # Example: Introduction\n(.*?)\n\nKey Findings\n(.*?)...
        pattern = r"(?s)"
        parts = []
        for i, h in enumerate(headings):
            if i == 0:
                pattern += rf"{re.escape(h)}\n(.*?)(?:(?=\n{re.escape(headings[1])}\n)|\Z)"
            else:
                # Not used directly; we parse iteratively below.
                pass

        sections: Dict[str, str] = {}
        # Iterative parse: find each heading start, slice until next heading.
        positions: List[int] = []
        for h in headings:
            m = re.search(rf"(?m)^{re.escape(h)}\s*$", t.strip())
            if m:
                positions.append(m.start())
            else:
                positions.append(-1)

        # If headings are missing, fallback to splitting by blank lines.
        if all(p == -1 for p in positions):
            return {"full_text": text}

        # Map heading -> start index
        start_map = {h: pos for h, pos in zip(headings, positions)}
        for idx, h in enumerate(headings):
            start = start_map[h]
            if start == -1:
                continue
            end = len(t)
            for j in range(idx + 1, len(headings)):
                nxt = start_map[headings[j]]
                if nxt != -1 and nxt > start:
                    end = nxt - 1
                    break
            sections[h] = t[start:end].strip()

        # Strip the heading text itself from each section value if present.
        for h in list(sections.keys()):
            sections[h] = re.sub(rf"(?m)^{re.escape(h)}\s*$", "", sections[h]).strip()

        return sections

    # Backwards-compatible method for older router code (kept so service doesn't crash).
    def review_item(self, item: Dict[str, Any]) -> Dict[str, Any]:
        return {**item, "confidence": 0.5}

