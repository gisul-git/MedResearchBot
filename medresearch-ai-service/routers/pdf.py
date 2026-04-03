from __future__ import annotations

from typing import Any, Dict, Optional
from uuid import uuid4

from fastapi import APIRouter, File, Form, UploadFile
from fastapi.responses import JSONResponse

from app.agents.pdf_agent import PDFAgent
import logging

router = APIRouter()

MAX_UPLOAD_BYTES = 50 * 1024 * 1024


@router.post("/pdf/upload")
async def upload_pdf(
    file: UploadFile = File(...),
    session_id: Optional[str] = Form(None),
) -> Dict[str, Any]:
    import logging
    logging.warning(f"UPLOAD_START: filename='{file.filename}' content_type='{file.content_type}'")

    if not session_id:
        session_id = str(uuid4())

    filename = (file.filename or "").lower()
    logging.warning(
        f"FILENAME_CHECK: filename='{filename}' ends_with_pdf={filename.endswith('.pdf')} content_type='{file.content_type}'"
    )
    if not filename.endswith(".pdf") and file.content_type not in ("application/pdf", "application/x-pdf"):
        logging.warning(f"REJECTED_FILETYPE: filename='{filename}' content_type='{file.content_type}'")
        return JSONResponse(status_code=400, content={"message": "Only PDF files are allowed"})

    file_bytes = await file.read()
    logging.warning(f"FILE_SIZE: {len(file_bytes)} bytes MAX={MAX_UPLOAD_BYTES}")
    if len(file_bytes) > MAX_UPLOAD_BYTES:
        return JSONResponse(status_code=413, content={"message": "File too large (max 50MB)"})

    # PHI scanning is handled by PDFAgent.ingest_pdf() per chunk.
    pass

    pdf_agent = PDFAgent()
    result = pdf_agent.ingest_pdf(file_bytes=file_bytes, session_id=session_id)
    logging.warning(f"INGEST_RESULT: {result}")
    # If agent rejects, bubble up.
    if result.get("status", "") != "stored":
        logging.warning(f"INGEST_STATUS_MISMATCH: status={result.get('status')} result={result}")
        status = result.get("status", "unknown")
        if status == "rejected_phi":
            message = "This PDF contains protected health information and cannot be processed."
        elif status == "no_text":
            message = "This PDF appears to be a scanned image. Please upload a text-based PDF where text can be selected."
        else:
            message = "This PDF could not be processed. Please try a different file."
        return JSONResponse(status_code=400, content={"message": message})

    # Requirement: return session_id
    return {"session_id": session_id}

