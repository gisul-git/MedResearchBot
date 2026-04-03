import logging
import hashlib
import uuid
from datetime import datetime, timezone
from typing import Any, Dict, Optional

from sqlalchemy import text
from urllib.parse import urlparse

from app.config import DATABASE_URL
from app.database import engine

logger = logging.getLogger("audit")


def audit_log_event(
    event_type: str,
    metadata: Optional[Dict[str, Any]] = None,
) -> None:
    """
    Lightweight audit hook.
    Expand later to persist audit records (DB/ELK/etc.).
    """

    payload = {
        "event_type": event_type,
        "ts": datetime.now(timezone.utc).isoformat(),
        "metadata": metadata or {},
    }
    logger.info(payload)


_AUDIT_LOG_INITIALIZED = False


def _get_db_username() -> Optional[str]:
    try:
        parsed = urlparse(DATABASE_URL)
        return parsed.username
    except Exception:
        return None


def init_audit_log_table() -> None:
    """
    Create the append-only audit log table.

    Retention: HIPAA requires audit logs to be retained for at least 6 years.
    """
    global _AUDIT_LOG_INITIALIZED
    if _AUDIT_LOG_INITIALIZED:
        return

    # Safety: if env is not set, do not attempt DB calls.
    if not DATABASE_URL:
        return

    username = _get_db_username()

    ddl = """
    CREATE TABLE IF NOT EXISTS audit_log (
      id uuid PRIMARY KEY,
      user_id varchar NOT NULL,
      action varchar NOT NULL,
      query_hash varchar NOT NULL,
      phi_violation boolean NOT NULL,
      timestamp timestamptz NOT NULL DEFAULT now(),
      ip_address varchar
    );

    COMMENT ON TABLE audit_log IS 'Rows must be retained for 6 years per HIPAA.';

    -- Enforce append-only semantics (block UPDATE/DELETE at the database level).
    CREATE OR REPLACE FUNCTION audit_log_no_update_delete() RETURNS trigger AS $$
    BEGIN
      RAISE EXCEPTION 'audit_log is append-only';
    END;
    $$ LANGUAGE plpgsql;

    DROP TRIGGER IF EXISTS audit_log_append_only_trigger ON audit_log;
    CREATE TRIGGER audit_log_append_only_trigger
      BEFORE UPDATE OR DELETE ON audit_log
      FOR EACH ROW EXECUTE FUNCTION audit_log_no_update_delete();

    -- Reduce risk surface: app should have INSERT-only semantics for this table.
    -- Note: if the DB user is the table owner, Postgres may still allow updates/deletes;
    -- the trigger above is the strong enforcement.
    REVOKE UPDATE, DELETE ON TABLE audit_log FROM PUBLIC;

    -- Also attempt to restrict the current user explicitly.
    REVOKE UPDATE, DELETE ON TABLE audit_log FROM CURRENT_USER;
    GRANT INSERT, SELECT ON TABLE audit_log TO CURRENT_USER;
    """

    try:
        with engine.begin() as conn:
            # Use driver-level SQL execution because the DDL contains multiple statements.
            conn.exec_driver_sql(ddl)
        _AUDIT_LOG_INITIALIZED = True
    except Exception as e:
        # Don't break request handling if DB isn't reachable at runtime.
        logger.warning({"msg": "audit_log init failed", "error": str(e), "db_user": username})


def _sha256_hex(query: str) -> str:
    return hashlib.sha256(query.encode("utf-8")).hexdigest()


def log_request(
    user_id: str,
    action: str,
    query: str,
    phi_violation: bool,
    ip_address: str,
) -> None:
    """
    Append an audit log entry.

    query is never stored raw; only SHA256(query) is stored in `query_hash`.
    """
    init_audit_log_table()

    query_hash = _sha256_hex(query)
    row_id = str(uuid.uuid4())

    stmt = text(
        """
        INSERT INTO audit_log (id, user_id, action, query_hash, phi_violation, timestamp, ip_address)
        VALUES (:id, :user_id, :action, :query_hash, :phi_violation, :timestamp, :ip_address)
        """
    )

    try:
        with engine.begin() as conn:
            conn.execute(
                stmt,
                {
                    "id": row_id,
                    "user_id": user_id,
                    "action": action,
                    "query_hash": query_hash,
                    "phi_violation": bool(phi_violation),
                    "timestamp": datetime.now(timezone.utc),
                    "ip_address": ip_address,
                },
            )
    except Exception as e:
        logger.warning({"msg": "audit_log insert failed", "error": str(e)})


def log_violation(
    user_id: str,
    phi_type: str,
    ip_address: str,
) -> None:
    # Log a violation entry without storing any raw query/text.
    # We treat phi_type as the 'query' input solely for hashing.
    log_request(
        user_id=user_id,
        action=f"phi_violation:{phi_type}",
        query=phi_type,
        phi_violation=True,
        ip_address=ip_address,
    )

