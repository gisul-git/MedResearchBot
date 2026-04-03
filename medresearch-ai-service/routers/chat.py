import re
from typing import Any, Dict, List, Literal, Optional

from fastapi import APIRouter
from fastapi.responses import JSONResponse
from pydantic import BaseModel

from app.agents.consensus_agent import ConsensusAgent
from app.agents.citation_agent import CitationAgent
from app.agents.pdf_agent import PDFAgent
from app.agents.review_agent import ReviewAgent
from app.agents.search_agent import SearchAgent
from app.phi_scanner import scan_text

router = APIRouter()

PHI_BLOCK_MESSAGE = "Request contains protected health information. Please remove identifying details."


# Only block if the generated output contains unambiguous PHI.
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


class ChatRequest(BaseModel):
    question: str
    session_id: Optional[str] = None
    chat_history: List[Any] = []
    mode: Literal["pdf_chat", "pubmed_search", "consensus", "review", "citation"]
    papers: Optional[List[Dict[str, Any]]] = None
    style: Optional[str] = None


@router.post("/chat")
async def chat(req: ChatRequest) -> Dict[str, Any]:
    import logging
    logging.warning(f"CHAT_ROUTER: mode={req.mode} question={req.question[:50]}")
    if req.mode == "pdf_chat":
        if not req.session_id:
            logging.warning("RETURNING_400: Missing session_id for pdf_chat mode")
            return JSONResponse(status_code=400, content={"message": "Missing session_id for pdf_chat mode"})

        agent = PDFAgent()
        logging.warning(f"CALLING_AGENT: {req.mode}")
        try:
            agent_result = agent.chat(
                question=req.question,
                session_id=req.session_id,
                chat_history=req.chat_history,
            )
        except Exception:
            import traceback
            logging.error(f"AGENT_ERROR: {traceback.format_exc()}")
            raise

        answer = agent_result.get("answer") or ""
        if _contains_strict_phi(str(answer)):
            logging.warning(f"RETURNING_400: {PHI_BLOCK_MESSAGE}")
            return JSONResponse(status_code=400, content={"message": PHI_BLOCK_MESSAGE})

        return agent_result

    if req.mode == "pubmed_search":
        agent = SearchAgent()
        logging.warning(f"CALLING_AGENT: {req.mode}")
        try:
            results = agent.search(query=req.question, max_pubmed_results=10)
        except Exception:
            import traceback
            logging.error(f"AGENT_ERROR: {traceback.format_exc()}")
            raise
        return {"results": results}

    if req.mode == "consensus":
        search_agent = SearchAgent()
        logging.warning(f"CALLING_AGENT: {req.mode}")
        try:
            papers = search_agent.search(query=req.question, max_pubmed_results=10)
        except Exception:
            import traceback
            logging.error(f"AGENT_ERROR: {traceback.format_exc()}")
            raise

        consensus_agent = ConsensusAgent()
        logging.warning(f"CALLING_AGENT: {req.mode}")
        try:
            analysis = consensus_agent.analyze(question=req.question, papers=papers)
        except Exception:
            import traceback
            logging.error(f"AGENT_ERROR: {traceback.format_exc()}")
            raise

        # Block if PHI somehow appears in the Ollama-driven analysis output.
        # Only scan Llama-generated fields, not PubMed paper titles/metadata.
        llama_output_to_scan = f"verdict:{analysis.get('verdict','')} confidence:{analysis.get('confidence_pct','')}"
        logging.warning(f"OUTPUT_SCAN_INPUT: {repr(llama_output_to_scan[:200])}")
        scan_result = scan_text(llama_output_to_scan)
        if not scan_result["is_safe"]:
            logging.warning(f"RETURNING_400: {PHI_BLOCK_MESSAGE}")
            return JSONResponse(status_code=400, content={"message": PHI_BLOCK_MESSAGE})

        return {"reply": analysis}

    if req.mode == "review":
        search_agent = SearchAgent()
        logging.warning(f"CALLING_AGENT: {req.mode}")
        try:
            papers = search_agent.search(query=req.question, max_pubmed_results=10)
        except Exception:
            import traceback
            logging.error(f"AGENT_ERROR: {traceback.format_exc()}")
            raise

        review_agent = ReviewAgent()
        logging.warning(f"CALLING_AGENT: {req.mode}")
        try:
            reviewed = review_agent.review(topic=req.question, papers=papers)
        except Exception:
            import traceback
            logging.error(f"AGENT_ERROR: {traceback.format_exc()}")
            raise

        # Router-level PHI block on Ollama output (review_text).
        review_text = str(reviewed.get("review_text") or "")
        if _contains_strict_phi(review_text):
            logging.warning(f"RETURNING_400: {PHI_BLOCK_MESSAGE}")
            return JSONResponse(status_code=400, content={"message": PHI_BLOCK_MESSAGE})

        return {"reply": reviewed}

    # req.mode == "citation"
    citation_agent = CitationAgent()
    logging.warning(f"CALLING_AGENT: {req.mode}")
    try:
        citation_result = citation_agent.format(
            papers=req.papers or [],
            style=req.style or "APA",
        )
    except Exception:
        import traceback
        logging.error(f"AGENT_ERROR: {traceback.format_exc()}")
        raise
    return {"reply": citation_result}

