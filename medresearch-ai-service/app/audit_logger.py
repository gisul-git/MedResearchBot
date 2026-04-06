import logging
import hashlib
from datetime import datetime

logger = logging.getLogger("audit")


def init_audit_log_table():
    pass


def log_request(user_id, action, query, phi_violation, ip_address):
    try:
        query_hash = hashlib.sha256(str(query).encode()).hexdigest()
        logger.info(f"REQUEST: user={user_id} action={action} phi={phi_violation}")
    except Exception:
        pass


def log_violation(user_id, phi_type, ip_address):
    try:
        logger.warning(f"PHI_VIOLATION: user={user_id} type={phi_type}")
    except Exception:
        pass

