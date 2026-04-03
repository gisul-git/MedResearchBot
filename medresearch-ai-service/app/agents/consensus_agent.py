from __future__ import annotations

from collections import Counter
from typing import Any, Dict, List, Literal

from langchain_community.chat_models import ChatOllama
from langchain_core.messages import HumanMessage, SystemMessage

from app.agents.pdf_agent import HIPAA_SYSTEM_PROMPT
from app.config import OLLAMA_BASE_URL


class ConsensusAgent:
    """
    Consensus agent that evaluates multiple papers with YES/NO/MIXED voting.
    """

    def analyze(self, question: str, papers: List[Dict[str, Any]]) -> Dict[str, Any]:
        llm = ChatOllama(model="llama3.1:8b", temperature=0, base_url=OLLAMA_BASE_URL)

        votes: List[Literal["YES", "NO", "MIXED"]] = []
        per_paper: List[Dict[str, Any]] = []

        # Limit to first 20 papers as required.
        for paper in (papers or [])[:20]:
            abstract = str(paper.get("abstract") or "")
            abstract = abstract[:4000]  # keep prompts small for speed
            title = str(paper.get("title") or "unknown title")

            prompt = (
                f"Abstract: {abstract}\n"
                f"Question: {question}\n"
                "Reply with exactly one word: YES, NO, or MIXED"
            )

            messages = [
                SystemMessage(content=HIPAA_SYSTEM_PROMPT),
                HumanMessage(content=prompt),
            ]

            resp = llm.invoke(messages)
            raw = getattr(resp, "content", None) or str(resp)
            ans = raw.strip().upper()
            if ans not in {"YES", "NO", "MIXED"}:
                # Be defensive: if the model returned extra tokens, extract the first matching word.
                for token in ["YES", "NO", "MIXED"]:
                    if token in ans:
                        ans = token
                        break
                else:
                    ans = "MIXED"

            votes.append(ans)  # type: ignore[arg-type]
            per_paper.append({"title": title, "verdict": ans})

        counts = Counter(votes)
        total = sum(counts.values()) or 1

        # Majority vote yields verdict; confidence is majority/total.
        majority = max(counts.items(), key=lambda kv: kv[1])[0] if counts else "MIXED"
        confidence_pct = int(round((counts.get(majority, 0) / total) * 100))

        return {
            "verdict": majority,
            "confidence_pct": confidence_pct,
            "per_paper": per_paper,
            "total_papers": len(per_paper),
        }

    # Backwards-compatible method for older router code (kept so service doesn't crash).
    def combine(self, candidates: List[Dict[str, Any]]) -> Dict[str, Any]:
        question = str((candidates or [{}])[0].get("question") or (candidates or [{}])[0].get("text") or "")
        papers = candidates
        return self.analyze(question=question, papers=papers)

