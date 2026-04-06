import uuid

from sqlalchemy import Boolean, Column, DateTime, String, create_engine
from sqlalchemy.dialects.postgresql import UUID as PG_UUID
from sqlalchemy.orm import declarative_base, sessionmaker
from sqlalchemy.sql import func

from app.config import DATABASE_URL, sqlalchemy_database_url

# SQLAlchemy engine setup using DATABASE_URL from `.env`.
database_url = DATABASE_URL or ""
engine = create_engine(
    sqlalchemy_database_url(database_url),
    connect_args={"sslmode": "require"} if "neon.tech" in database_url else {},
    pool_pre_ping=True,
    pool_recycle=300,
)

SessionLocal = sessionmaker(autocommit=False, autoflush=False, bind=engine)

Base = declarative_base()


class AuditLog(Base):
    """
    Matches the `audit_log` table used by app/audit_logger.py.
    """

    __tablename__ = "audit_log"

    id = Column(PG_UUID(as_uuid=True), primary_key=True, default=uuid.uuid4)
    user_id = Column(String, nullable=False)
    action = Column(String, nullable=False)
    query_hash = Column(String, nullable=False)
    phi_violation = Column(Boolean, nullable=False)
    timestamp = Column(DateTime(timezone=True), nullable=False, server_default=func.now())
    ip_address = Column(String)


def get_db():
    """
    FastAPI dependency that provides a SQLAlchemy session.
    """
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()

