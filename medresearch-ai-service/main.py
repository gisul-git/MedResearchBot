try:
    __import__("pysqlite3")
    import sys
    sys.modules["sqlite3"] = sys.modules.pop("pysqlite3")
except ImportError:
    pass

import asyncio
import json
import os
import time
from typing import Any, Dict, List, Optional
from contextlib import asynccontextmanager

import httpx
from fastapi import FastAPI, Request
from fastapi.middleware.cors import CORSMiddleware
from fastapi.responses import JSONResponse
from starlette.middleware.base import BaseHTTPMiddleware

from app.auth import verify_token
from app.audit_logger import log_request, log_violation
from app.audit_logger import init_audit_log_table
from app.config import OLLAMA_BASE_URL
from app.phi_scanner import scan_text
from routers.chat import router as chat_router
from routers.pdf import router as pdf_router
from routers.search import router as search_router

@asynccontextmanager
async def lifespan(app: FastAPI):
    init_audit_log_table()
    yield


app = FastAPI(title="medresearch-ai-service", lifespan=lifespan)

# In-memory rate limiting: 60 req/min per user_id.
RATE_LIMIT_WINDOW_SECONDS = 60
RATE_LIMIT_MAX_REQUESTS = 60
_rate_limit_store: Dict[str, List[float]] = {}
_rate_limit_lock = asyncio.Lock()

MAX_SCAN_CHARS = 20_000  # Keep middleware fast under typical query sizes.


def _extract_bearer_token(auth_header: Optional[str]) -> Optional[str]:
    if not auth_header:
        return None
    parts = auth_header.split()
    if len(parts) != 2:
        return None
    if parts[0].lower() != "bearer":
        return None
    return parts[1]


class HipaaGuardMiddleware(BaseHTTPMiddleware):
    async def dispatch(self, request: Request, call_next):
        import logging
        logging.warning(f"MIDDLEWARE_START: {request.method} {request.url.path}")
        EXEMPT_PATHS = {"/health", "/docs", "/openapi.json", "/redoc"}
        if request.url.path in EXEMPT_PATHS:
            return await call_next(request)

        # Preflight requests should not be blocked by JWT checks.
        # (Browsers often omit Authorization on OPTIONS preflight.)
        if request.method == "OPTIONS":
            return await call_next(request)

        # 1) Verify JWT token if provided; allow anonymous access when missing.
        auth_header = request.headers.get("Authorization", "")
        user_id = "anonymous"
        if auth_header.startswith("Bearer "):
            token = auth_header.split(" ", 1)[1]
            if token:
                try:
                    user_id = verify_token(token)
                except Exception:
                    return JSONResponse(
                        status_code=401,
                        content={"detail": "Invalid token"},
                    )
        logging.warning(f"JWT_PASSED: user_id={user_id}")

        # 2) Rate limit per user_id
        now = time.monotonic()
        cutoff = now - RATE_LIMIT_WINDOW_SECONDS
        async with _rate_limit_lock:
            timestamps = _rate_limit_store.get(user_id, [])
            timestamps = [t for t in timestamps if t >= cutoff]
            if len(timestamps) >= RATE_LIMIT_MAX_REQUESTS:
                return JSONResponse(status_code=429, content={"detail": "Rate limit exceeded"})
            timestamps.append(now)
            _rate_limit_store[user_id] = timestamps
        logging.warning("RATE_LIMIT_PASSED")

        # Multipart uploads: do not read body here (would consume the stream) or scan binary as text.
        # PDF router runs PHI scan after text extraction.
        content_type = request.headers.get("content-type", "")
        if "multipart/form-data" in content_type:
            return await call_next(request)

        # 3) Extract request body and scan for PHI (JSON: only question/topic/text, not raw keys/ids)
        body_bytes = await request.body()
        if not body_bytes:
            body_text = ""
        else:
            # Truncate bytes before decode to keep latency bounded.
            body_bytes = body_bytes[: MAX_SCAN_CHARS * 4]
            body_text = body_bytes.decode("utf-8", errors="ignore")
            if len(body_text) > MAX_SCAN_CHARS:
                body_text = body_text[:MAX_SCAN_CHARS]

        text_to_scan = body_text
        if request.headers.get("content-type", "").startswith("application/json"):
            try:
                body_json = json.loads(body_text)
                text_to_scan = " ".join(
                    [
                        str(body_json.get("question", "")),
                        str(body_json.get("topic", "")),
                        str(body_json.get("text", "")),
                    ]
                )
            except Exception:
                text_to_scan = body_text

        import logging
        logging.warning(f"PHI_SCAN_INPUT: {repr(text_to_scan[:200])}")
        scan_result = scan_text(text_to_scan)
        logging.warning(
            f"PHI_SCAN_RESULT: is_safe={scan_result['is_safe']} violations={scan_result['violations']}"
        )

        # 4) PHI detected -> log violations + reject
        if not scan_result["is_safe"]:
            logging.warning("PHI_BLOCKED: returning 400")
            ip_address = request.client.host if request.client else ""
            for v in scan_result["violations"]:
                log_violation(user_id=user_id, phi_type=v["phi_type"], ip_address=ip_address)

            return JSONResponse(
                status_code=400,
                content={"message": "Request contains protected health information. Please remove identifying details."},
            )

        # 5) Clean -> append-only audit log request + route handler
        ip_address = request.client.host if request.client else ""
        action = f"{request.method}:{request.url.path}"
        log_request(
            user_id=user_id,
            action=action,
            query=text_to_scan,
            phi_violation=False,
            ip_address=ip_address,
        )

        return await call_next(request)


# Last-added middleware runs first (outermost). HIPAA first, CORS second => CORS wraps responses.
app.add_middleware(HipaaGuardMiddleware)
app.add_middleware(
    CORSMiddleware,
    allow_origins=[
        "http://localhost:64631",
        "http://localhost:5000",
        "http://localhost:3000",
        os.getenv("ALLOWED_ORIGIN", "http://localhost:64631"),
        "https://medresearchninja-cgaseea0b0ejgyfq.southindia-01.azurewebsites.net",
    ],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

app.include_router(chat_router, prefix="/api", tags=["chat"])
app.include_router(pdf_router, prefix="/api", tags=["pdf"])
app.include_router(search_router, prefix="/api", tags=["search"])


@app.get("/health")
async def health() -> Dict[str, Any]:
    # Check Ollama connectivity (best-effort).
    connected = "not_connected"
    base = OLLAMA_BASE_URL.rstrip("/")
    try:
        timeout = httpx.Timeout(5.0)
        async with httpx.AsyncClient(timeout=timeout) as client:
            resp = await client.get(f"{base}/api/tags")
            if 200 <= resp.status_code < 300:
                connected = "connected"
    except Exception:
        connected = "not_connected"

    return {
        "status": "ok",
        "phi_scanner": "active",
        "ollama": connected,
        "ollama_base_url": OLLAMA_BASE_URL,
    }

