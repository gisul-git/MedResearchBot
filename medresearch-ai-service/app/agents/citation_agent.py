from __future__ import annotations

import re
from typing import Any, Dict, List


class CitationAgent:
    """
    Formats paper metadata into citation strings (APA/MLA/Vancouver).
    """

    def format(self, papers: List[Dict[str, Any]], style: str) -> Dict[str, Any]:
        style_norm = (style or "").strip().upper()
        if style_norm not in {"APA", "MLA", "VANCOUVER"}:
            style_norm = "VANCOUVER" if style_norm == "V" else "APA"

        citations: List[str] = []
        for p in (papers or []):
            citations.append(self._format_one(p, style_norm))

        return {"citations": citations, "style": style_norm, "count": len(citations)}

    def _format_one(self, paper: Dict[str, Any], style: str) -> str:
        title = str(paper.get("title") or "")
        journal = str(paper.get("journal") or paper.get("source") or "")
        year = str(paper.get("year") or "")
        authors = paper.get("authors") or []
        if isinstance(authors, str):
            authors = [authors]

        author_str = self._format_authors(authors, style)

        if style == "APA":
            # APA: Author, A. A. (Year). Title. Journal.
            y = f"({year})." if year else "(n.d.)."
            return f"{author_str} {y} {title}. {journal}".replace("  ", " ").strip()

        if style == "MLA":
            # MLA: Author. "Title." Journal, Year.
            y = f", {year}" if year else ""
            return f"{author_str}. \"{title}.\" {journal}{y}.".replace("  ", " ").strip()

        # Vancouver: Author. Title. Journal. Year.
        year_part = year if year else ""
        if year_part:
            return f"{author_str}. {title}. {journal}. {year_part}."
        return f"{author_str}. {title}. {journal}."

    def _format_authors(self, authors: List[Any], style: str) -> str:
        names: List[str] = [str(a) for a in authors if str(a).strip()]
        if not names:
            return "Unknown"

        # Convert "First Last" -> "Last, F."; handles "Initials Last" approximately.
        formatted: List[str] = []
        for n in names:
            parts = [p for p in re.split(r"\s+", n.strip()) if p]
            if len(parts) == 1:
                formatted.append(parts[0])
                continue
            last = parts[-1]
            first_parts = parts[:-1]
            initials = "".join([p[0].upper() + "." for p in first_parts if p and p[0].isalpha()])
            formatted.append(f"{last}, {initials}".strip().replace(" ,", ","))

        if style == "APA":
            if len(formatted) == 1:
                return formatted[0]
            if len(formatted) == 2:
                return f"{formatted[0]} & {formatted[1]}"
            return "; ".join(formatted[:3]) + ("; ..." if len(formatted) > 3 else "")

        if style == "MLA":
            # MLA often lists first author then et al. We'll keep it simple.
            if len(formatted) == 1:
                return formatted[0]
            return formatted[0].replace(",", "") + " et al."

        # Vancouver: "Last F., Last F."
        return ", ".join([f.replace(",", "") for f in formatted])

    # Backwards-compatible method for earlier stub code.
    def cite(self, item: Dict[str, Any]) -> Dict[str, Any]:
        return {"citation": "stub-citation", **item}

