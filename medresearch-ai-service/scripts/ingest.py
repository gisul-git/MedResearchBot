from __future__ import annotations

import argparse
import logging
import sys
from datetime import datetime, timezone
from pathlib import Path
from typing import Any, Dict, List, Tuple

# Ensure `app` package imports work when run as:
# `python scripts/ingest.py --folder ./docs`
PROJECT_ROOT = Path(__file__).resolve().parents[1]
if str(PROJECT_ROOT) not in sys.path:
    sys.path.insert(0, str(PROJECT_ROOT))

from langchain_community.document_loaders import PyPDFLoader
from langchain_community.vectorstores import Chroma
from langchain_community.embeddings import HuggingFaceEmbeddings
from langchain_text_splitters import RecursiveCharacterTextSplitter

from app.config import CHROMA_DB_PATH
from app.phi_scanner import scan_text

logger = logging.getLogger("ingest")


def _safe_page_number(md: Dict[str, Any]) -> Any:
    # PyPDFLoader commonly uses `page` in metadata.
    if "page_number" in md:
        return md["page_number"]
    if "page" in md:
        return md["page"]
    return 0


def main() -> None:
    logging.basicConfig(level=logging.INFO)

    parser = argparse.ArgumentParser(description="Ingest research PDFs into ChromaDB.")
    parser.add_argument("--folder", required=True, help="Folder containing PDFs to ingest (recursively).")
    args = parser.parse_args()

    folder = Path(args.folder).expanduser().resolve()
    if not folder.exists():
        raise SystemExit(f"Folder does not exist: {folder}")

    pdf_paths = sorted([p for p in folder.rglob("*.pdf") if p.is_file()])
    if not pdf_paths:
        raise SystemExit(f"No PDFs found in folder: {folder}")

    splitter = RecursiveCharacterTextSplitter(
        chunk_size=500,
        chunk_overlap=50,
    )

    embeddings = HuggingFaceEmbeddings(model_name="sentence-transformers/all-MiniLM-L6-v2")
    vectorstore = Chroma(persist_directory=CHROMA_DB_PATH, embedding_function=embeddings)

    total_files = 0
    total_chunks = 0
    skipped_phi = 0
    stored_chunks = 0

    ingested_at = datetime.now(timezone.utc).isoformat()

    for pdf_path in pdf_paths:
        total_files += 1
        source_file = pdf_path.name

        loader = PyPDFLoader(str(pdf_path))
        pages = loader.load()  # one Document per page

        file_chunk_index = 0
        for page_doc in pages:
            page_md = getattr(page_doc, "metadata", {}) or {}
            page_number = _safe_page_number(page_md)

            # Split per-page to preserve page_number metadata.
            chunk_docs = splitter.split_documents([page_doc])
            for chunk in chunk_docs:
                total_chunks += 1

                chunk_md = getattr(chunk, "metadata", {}) or {}
                chunk_md["source_file"] = source_file
                chunk_md["page_number"] = page_number
                chunk_md["chunk_index"] = file_chunk_index
                chunk_md["ingested_at"] = ingested_at
                # Stable ID for dedup/troubleshooting; used by SearchAgent.
                chunk_md["doc_id"] = f"{source_file}:{page_number}:{file_chunk_index}"
                chunk.metadata = chunk_md

                scan = scan_text(getattr(chunk, "page_content", "") or "")
                if not scan.get("is_safe", True):
                    skipped_phi += 1
                    logger.warning(
                        "Skipping chunk due to PHI. source=%s page=%s chunk_index=%s violations=%s",
                        source_file,
                        page_number,
                        file_chunk_index,
                        [v.get("phi_type") for v in scan.get("violations", [])],
                    )
                    file_chunk_index += 1
                    continue

                stored_chunks += 1
                file_chunk_index += 1

                # Add one chunk at a time to keep memory small; Chroma accepts lists.
                vectorstore.add_documents([chunk])

    vectorstore.persist()

    print(
        "Ingestion complete\n"
        f"Total files: {total_files}\n"
        f"Total chunks: {total_chunks}\n"
        f"Chunks skipped (PHI): {skipped_phi}\n"
        f"Chunks stored: {stored_chunks}\n"
        f"Chroma DB path: {CHROMA_DB_PATH}"
    )


if __name__ == "__main__":
    main()

