from typing import Any, Dict, List

from fastapi import APIRouter
from pydantic import BaseModel

from app.agents.search_agent import SearchAgent

router = APIRouter()


class SearchRequest(BaseModel):
    query: str


@router.post("/search")
async def search(req: SearchRequest) -> Dict[str, List[Dict[str, Any]]]:
    agent = SearchAgent()
    results = agent.search(query=req.query, max_pubmed_results=10)
    return {"results": results}

