import os

from dotenv import load_dotenv

load_dotenv()


class Settings:
    DATABASE_URL: str = os.getenv("DATABASE_URL", "")
    SECRET_KEY: str = os.getenv("SECRET_KEY", "")
    OLLAMA_BASE_URL: str = os.getenv("OLLAMA_BASE_URL", "http://localhost:11434")
    CHROMA_DB_PATH: str = os.getenv("CHROMA_DB_PATH", "./chroma_db")
    JWT_ALGORITHM: str = os.getenv("JWT_ALGORITHM", "HS256")
    JWT_EXPIRE_MINUTES: int = int(os.getenv("JWT_EXPIRE_MINUTES", "60"))
    ALLOWED_ORIGIN: str = os.getenv("ALLOWED_ORIGIN", "http://localhost:64631")
    DOCKER_ENV: bool = os.getenv("DOCKER_ENV", "false").lower() == "true"


settings = Settings()

# Backwards-compatible module-level constants used across the app.
SECRET_KEY: str = settings.SECRET_KEY
DATABASE_URL: str = settings.DATABASE_URL
OLLAMA_BASE_URL: str = settings.OLLAMA_BASE_URL
if settings.DOCKER_ENV:
    # Inside Docker on Windows/Mac, `localhost` refers to the container itself.
    # `host.docker.internal` routes back to the host machine's Ollama.
    OLLAMA_BASE_URL = OLLAMA_BASE_URL.replace("localhost", "host.docker.internal")
CHROMA_DB_PATH: str = settings.CHROMA_DB_PATH
JWT_ALGORITHM: str = settings.JWT_ALGORITHM
JWT_EXPIRE_MINUTES: int = settings.JWT_EXPIRE_MINUTES
ALLOWED_ORIGIN: str = settings.ALLOWED_ORIGIN


def sqlalchemy_database_url(database_url: str = DATABASE_URL) -> str:
    """
    SQLAlchemy wants a driver in the URL for psycopg2.
    Keep DATABASE_URL compatible with the requested `.env.example` format.
    """

    if database_url.startswith("postgresql://"):
        return database_url.replace("postgresql://", "postgresql+psycopg2://", 1)
    return database_url
