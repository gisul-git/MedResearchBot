from __future__ import annotations

import re
from dataclasses import dataclass
from typing import Any, Dict, List, Optional, Sequence, Set, Tuple


@dataclass
class PHIScanResult:
    is_phi: bool
    redacted_text: str


# --- Regex patterns ---

# Contact info
EMAIL_RE = re.compile(
    r"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b",
    re.IGNORECASE,
)

# Very common phone patterns with optional country code.
PHONE_RE = re.compile(
    r"(?<!\w)(?:\+?1[\s.-]?)?(?:\(\s*\d{3}\s*\)|\d{3})[\s.-]?\d{3}[\s.-]?\d{4}(?!\w)",
)

# Fax numbers are usually labeled, but can still be number-only.
FAX_RE = re.compile(
    r"(?<!\w)fax\s*[:\-]?\s*(?:\+?1[\s.-]?)?(?:\(\s*\d{3}\s*\)|\d{3})[\s.-]?\d{3}[\s.-]?\d{4}(?!\w)",
    re.IGNORECASE,
)

# HIPAA Safe Harbor SSN
SSN_RE = re.compile(
    r"\b(?!000|666|9\d\d)\d{3}-(?!00)\d{2}-(?!0000)\d{4}\b",
)

# Dates: DOB/admission/discharge dates, matching month/day formats WITHOUT requiring a year.
MD_NUMERIC_SEP_RE = re.compile(
    r"\b(?:(?:0?[1-9]|1[0-2])[\/\-.](?:0?[1-9]|[12]\d|3[01]))(?![\/\-.]\d{1,4})\b"
)

MONTH_NAME_RE = re.compile(
    r"\b("
    r"Jan(?:uary)?|Feb(?:ruary)?|Mar(?:ch)?|Apr(?:il)?|May|Jun(?:e)?|Jul(?:y)?|Aug(?:ust)?|"
    r"Sep(?:tember)?|Oct(?:ober)?|Nov(?:ember)?|Dec(?:ember)?"
    r")\s+(?:0?[1-9]|[12]\d|3[01])\b(?!\s+\d{4})",
    re.IGNORECASE,
)

# Geographic: US zip + simple street/city/state patterns.
ZIP_RE = re.compile(r"\b\d{5}(?:-\d{4})?\b")
STREET_RE = re.compile(
    r"\b\d{1,6}\s+(?:[A-Za-z0-9.\s]+?)\s+"
    r"(?:St|Street|Ave|Avenue|Rd|Road|Blvd|Boulevard|Dr|Drive|Ln|Lane|Ct|Court|"
    r"Way|Pl|Place|Terrace|Terr|Circle|Cir)\b",
    re.IGNORECASE,
)
CITY_STATE_ZIP_RE = re.compile(
    r"\b([A-Z][A-Za-z]+(?:\s+[A-Z][A-Za-z]+)*),\s*"
    r"([A-Z]{2})\s+\d{5}(?:-\d{4})?\b"
)

GEOGRAPHIC_RE = re.compile(
    rf"(?:{ZIP_RE.pattern})|(?:{STREET_RE.pattern})|(?:{CITY_STATE_ZIP_RE.pattern})",
    re.IGNORECASE,
)

# Identifiers (labeled patterns where possible to reduce false positives)
MRN_RE = re.compile(
    r"\b(?:MRN|Medical\s*Record\s*Number|Medical\s*Record)\s*[:#]?\s*[A-Za-z0-9-]{5,}\b",
    re.IGNORECASE,
)
HPCBN_RE = re.compile(
    r"\b(?:HICN|Health\s*Plan\s*Beneficiary|Health\s*Plan\s*Beneficiary\s*Number|"
    r"Beneficiary|Card\s*Number)\s*[:#]?\s*[A-Za-z0-9-]{5,}\b",
    re.IGNORECASE,
)
ACCOUNT_RE = re.compile(
    r"\b(?:Account|Acct|Policy|Policy\s*Number|Member\s*Number|Member|Subscriber|Card)\s*"
    r"[:#]?\s*[A-Za-z0-9-]{6,}\b",
    re.IGNORECASE,
)

CERT_LICENSE_RE = re.compile(
    r"\b(?:License|Lic#|Cert|Certificate)\s*[:#]?\s*[A-Za-z0-9-]{4,}\b",
    re.IGNORECASE,
)

# Vehicle identifiers: VIN and serial numbers
VIN_RE = re.compile(r"\b[A-HJ-NPR-Z0-9]{17}\b")
SERIAL_RE = re.compile(
    r"\b(?:VIN|Serial\s*Number|S\/N|S-N|Serial)\s*[:#]?\s*[A-Za-z0-9-]{4,}\b",
    re.IGNORECASE,
)

VEHICLE_RE = re.compile(rf"(?:{VIN_RE.pattern})|(?:{SERIAL_RE.pattern})", re.IGNORECASE)

# Device identifiers: IMEI, MEID, MAC, ICCID, etc.
IMEI_RE = re.compile(r"\b(?:\d{15}|\d{17})\b")
MAC_RE = re.compile(r"\b(?:[0-9A-Fa-f]{2}:){5}[0-9A-Fa-f]{2}\b")
DEVICE_ID_RE = re.compile(
    r"\b(?:IMEI|MEID|ICCID|MAC|Device\s*ID|DID|Serial)\s*[:#]?\s*[A-Za-z0-9-]{6,}\b",
    re.IGNORECASE,
)
DEVICE_RE = re.compile(rf"(?:{IMEI_RE.pattern})|(?:{MAC_RE.pattern})|(?:{DEVICE_ID_RE.pattern})", re.IGNORECASE)

# Biometric identifiers (fingerprint, voiceprint) - typically feature strings/hashes.
BIOMETRIC_RE = re.compile(
    r"\b(?:fingerprint|voiceprint)\b.{0,50}\b(?:[A-Za-z0-9+/]{20,}={0,2}|[A-Fa-f0-9]{32,})\b",
    re.IGNORECASE | re.DOTALL,
)

# Full-face photographs: base64 image payloads
BASE64_IMAGE_DATA_RE = re.compile(
    r"\b(?:data:image/(?:png|jpeg|jpg|webp);base64,)"
    r"(?:[A-Za-z0-9+/]{200,}={0,2})\b",
    re.IGNORECASE,
)
BASE64_PNG_HEADER_RE = re.compile(
    r"\b(?:iVBORw0KGgo)[A-Za-z0-9+/]{200,}={0,2}\b",
    re.IGNORECASE,
)
BASE64_JPEG_HEADER_RE = re.compile(
    r"\b(?:/9j/)[A-Za-z0-9+/]{200,}={0,2}\b",
    re.IGNORECASE,
)

FULL_FACE_PHOTO_RE = re.compile(
    rf"(?:{BASE64_IMAGE_DATA_RE.pattern})|(?:{BASE64_PNG_HEADER_RE.pattern})|(?:{BASE64_JPEG_HEADER_RE.pattern})",
    re.IGNORECASE,
)

# Web URLs and IP addresses
URL_RE = re.compile(
    r"\b(?:https?://|www\.)[A-Za-z0-9\-._~:/?#\[\]@!$&'()*+,;=%]+",
    re.IGNORECASE,
)

IPV4_RE = re.compile(
    r"\b(?:(?:25[0-5]|2[0-4]\d|1?\d?\d)\.){3}(?:25[0-5]|2[0-4]\d|1?\d?\d)\b"
)
IPV6_RE = re.compile(
    r"\b(?:[A-Fa-f0-9]{1,4}:){1,7}[A-Fa-f0-9]{1,4}\b"
)
IP_RE = re.compile(rf"(?:{IPV4_RE.pattern})|(?:{IPV6_RE.pattern})")

# Name detection: only after explicit context (avoids medical phrases like "insulin sensitivity").
NAME_CONTEXT_PATTERN = re.compile(
    r"\b(patient|subject|participant|mr\.|mrs\.|ms\.|dr\.|name[d]?|called)\s+([A-Z][a-z]+\s+[A-Z][a-z]+)\b",
    re.IGNORECASE,
)

# Any unique identifying number or code
UNIQUE_CODE_RE = re.compile(
    r"\b(?:Unique\s*(?:ID|Identifier|Code|Number)|ID|Identifier|Code)\s*[:#]?\s*[A-Za-z0-9-]{6,}\b",
    re.IGNORECASE,
)

LONG_ALNUM_RE = re.compile(r"\b[A-Za-z0-9]{12,}\b")


# Assemble categories (HIPAA Safe Harbor list)
PHI_REGEX_CATEGORIES: Sequence[Tuple[str, re.Pattern[str]]] = (
    ("Geographic data", GEOGRAPHIC_RE),
    ("Dates", re.compile(rf"(?:{MD_NUMERIC_SEP_RE.pattern})|(?:{MONTH_NAME_RE.pattern})", re.IGNORECASE)),
    ("Phone numbers", PHONE_RE),
    ("Fax numbers", FAX_RE),
    ("Email addresses", EMAIL_RE),
    ("Social Security Numbers", SSN_RE),
    ("Medical record numbers", MRN_RE),
    ("Health plan beneficiary numbers", HPCBN_RE),
    ("Account numbers", ACCOUNT_RE),
    ("Certificate/license numbers", CERT_LICENSE_RE),
    ("Vehicle identifiers and serial numbers", VEHICLE_RE),
    ("Device identifiers", DEVICE_RE),
    ("Web URLs", URL_RE),
    ("IP addresses", IP_RE),
    ("Biometric identifiers", BIOMETRIC_RE),
    ("Full-face photographs", FULL_FACE_PHOTO_RE),
    ("Any unique identifying number or code", re.compile(rf"(?:{UNIQUE_CODE_RE.pattern})|(?:{LONG_ALNUM_RE.pattern})", re.IGNORECASE)),
)


def scan_text(text: str) -> Dict[str, Any]:
    """
    Fast PHI scanner.

    Returns:
      - is_safe: bool
      - violations: list of {phi_type, matched_pattern}
    """
    if text is None:
        text = ""

    # Fast path for very short inputs.
    if len(text) < 3:
        return {"is_safe": True, "violations": []}

    lower = text.lower()
    has_at = "@" in text
    has_digits = any(ch.isdigit() for ch in text)
    has_http = ("http://" in lower) or ("https://" in lower) or ("www." in lower)
    has_base64 = ("base64" in lower) or ("data:image" in lower)
    has_biometrics = ("fingerprint" in lower) or ("voiceprint" in lower)

    violations: List[Dict[str, str]] = []
    found_types: Set[str] = set()

    # 1) Name detection (context-prefixed capitalized pairs only)
    if NAME_CONTEXT_PATTERN.search(text):
        violations.append({"phi_type": "Names", "matched_pattern": NAME_CONTEXT_PATTERN.pattern})
        found_types.add("Names")

    # 2) Regex categories
    for phi_type, pattern in PHI_REGEX_CATEGORIES:
        if phi_type in found_types:
            continue

        # Heuristic skips for speed (avoid obvious non-matches).
        if phi_type == "Email addresses" and not has_at:
            continue
        if phi_type == "Web URLs" and not has_http:
            continue
        if phi_type == "Biometric identifiers" and not has_biometrics:
            continue
        if phi_type == "Full-face photographs" and not has_base64:
            continue
        if phi_type in {
            "Geographic data",
            "Dates",
            "Phone numbers",
            "Fax numbers",
            "Social Security Numbers",
            "Medical record numbers",
            "Health plan beneficiary numbers",
            "Account numbers",
            "Certificate/license numbers",
            "Vehicle identifiers and serial numbers",
            "Device identifiers",
            "IP addresses",
            "Any unique identifying number or code",
        } and not has_digits:
            continue

        if pattern.search(text):
            violations.append({"phi_type": phi_type, "matched_pattern": pattern.pattern})
            found_types.add(phi_type)

    return {"is_safe": len(violations) == 0, "violations": violations}


def redact_text(text: str) -> str:
    """
    Replace detected PHI with [REDACTED-TYPE].
    """
    if text is None:
        return ""

    scan = scan_text(text)
    if scan["is_safe"]:
        return text

    types = {v["phi_type"] for v in scan["violations"]}
    redacted = text

    if "Names" in types:
        redacted = NAME_CONTEXT_PATTERN.sub("[REDACTED-Names]", redacted)

    # All other regex categories
    for phi_type, pattern in PHI_REGEX_CATEGORIES:
        if phi_type not in types:
            continue
        redacted = pattern.sub(f"[REDACTED-{phi_type}]", redacted)

    return redacted


class PHIScanner:
    """
    Backwards-compatible wrapper around module-level functions.
    """

    def scan_text(self, text: str) -> PHIScanResult:
        result = scan_text(text)
        return PHIScanResult(is_phi=not result["is_safe"], redacted_text=redact_text(text))

