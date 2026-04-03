import os

from dotenv import load_dotenv

load_dotenv()


def _get_env(key: str, default: str) -> str:
    value = os.getenv(key)
    return value if value not in (None, "") else default


SECRET_KEY: str = _get_env("SECRET_KEY", "change-me")
DATABASE_URL: str = _get_env(
    "DATABASE_URL",
    "postgresql://user:password@localhost:5432/medresearch",
)
OLLAMA_BASE_URL: str = _get_env("OLLAMA_BASE_URL", "http://localhost:11434")
if _get_env("DOCKER_ENV", "false").lower() == "true":
    # Inside Docker on Windows/Mac, `localhost` refers to the container itself.
    # `host.docker.internal` routes back to the host machine's Ollama.
    OLLAMA_BASE_URL = OLLAMA_BASE_URL.replace("localhost", "host.docker.internal")
CHROMA_DB_PATH: str = _get_env("CHROMA_DB_PATH", "./chroma_db")
JWT_ALGORITHM: str = _get_env("JWT_ALGORITHM", "HS256")
JWT_EXPIRE_MINUTES: int = int(_get_env("JWT_EXPIRE_MINUTES", "60"))


def sqlalchemy_database_url(database_url: str = DATABASE_URL) -> str:
    """
    SQLAlchemy wants a driver in the URL for psycopg2.
    Keep DATABASE_URL compatible with the requested `.env.example` format.
    """

    if database_url.startswith("postgresql://"):
        return database_url.replace("postgresql://", "postgresql+psycopg2://", 1)
    return database_url
