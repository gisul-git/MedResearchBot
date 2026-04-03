(function () {
  "use strict";

  var API_BASE = (window.MEDRESEARCH_API_URL || "").replace(/\/+$/, "");
  var TOKEN_KEY = "medresearch_token";
  var SESSION_KEY = "medresearch_session";

  var PHI_PATTERNS = {
    ssn: /\b\d{3}-\d{2}-\d{4}\b/,
    phone: /\b\d{3}[-.\s]\d{3}[-.\s]\d{4}\b/,
    email: /\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b/i,
    dob: /\b(0?[1-9]|1[0-2])[\/\-](0?[1-9]|[12]\d|3[01])[\/\-](\d{2}|\d{4})\b/,
    ip: /\b(?:\d{1,3}\.){3}\d{1,3}\b/
  };

  var MODES = [
    { value: "pubmed_search", label: "Search PubMed Papers" },
    { value: "pdf_chat", label: "Chat with PDF" },
    { value: "consensus", label: "Consensus Check" },
    { value: "review", label: "Literature Review" },
    { value: "citation", label: "Generate Citations" }
  ];

  var state = {
    open: false,
    mode: "pubmed_search",
    chatHistory: []
  };

  function getOrCreateSessionId() {
    var existing = sessionStorage.getItem(SESSION_KEY);
    if (existing) return existing;
    var id;
    if (window.crypto && window.crypto.randomUUID) {
      id = window.crypto.randomUUID();
    } else {
      id = "xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx".replace(/[xy]/g, function (c) {
        var r = (Math.random() * 16) | 0;
        var v = c === "x" ? r : (r & 0x3) | 0x8;
        return v.toString(16);
      });
    }
    sessionStorage.setItem(SESSION_KEY, id);
    return id;
  }

  var sessionId = getOrCreateSessionId();

  function injectStyles() {
    var css = ""
      + ".mr-chat-btn{position:fixed;right:24px;bottom:24px;z-index:99999;background:#0066cc;color:#fff;border:none;border-radius:28px;padding:12px 16px;display:flex;gap:8px;align-items:center;font:600 14px/1.2 Arial,sans-serif;cursor:pointer;box-shadow:0 10px 24px rgba(0,0,0,.22)}"
      + ".mr-chat-btn:hover{filter:brightness(1.05)}"
      + ".mr-chat-panel{position:fixed;bottom:90px;right:24px;width:400px;height:580px;z-index:99999;background:#fff;color:#111;border-radius:14px;box-shadow:0 20px 40px rgba(0,0,0,.26);display:none;flex-direction:column;overflow:hidden;border:1px solid rgba(0,0,0,.1)}"
      + ".mr-chat-header{display:flex;justify-content:space-between;align-items:center;padding:12px 14px;background:#f7f9fc;border-bottom:1px solid #e7ebf3;font:700 15px/1.2 Arial,sans-serif}"
      + ".mr-chat-close{border:none;background:transparent;font-size:20px;line-height:1;cursor:pointer;color:#4b5563}"
      + ".mr-chat-tools{display:flex;gap:8px;align-items:center;padding:10px 12px;border-bottom:1px solid #eef2f7;background:#fff}"
      + ".mr-chat-select,.mr-chat-upload{font:13px Arial,sans-serif;border:1px solid #d6dbe5;border-radius:8px;padding:8px;background:#fff;color:#111}"
      + ".mr-chat-select{flex:1}"
      + ".mr-chat-upload{display:none;max-width:45%}"
      + ".mr-chat-messages{flex:1;overflow:auto;padding:12px;display:flex;flex-direction:column;gap:10px;background:#fcfdff}"
      + ".mr-msg{max-width:84%;padding:9px 11px;border-radius:12px;font:13px/1.45 Arial,sans-serif;word-wrap:break-word;white-space:pre-wrap}"
      + ".mr-msg-user{align-self:flex-end;background:#0066cc;color:#fff;border-bottom-right-radius:4px}"
      + ".mr-msg-ai{align-self:flex-start;background:#edf1f6;color:#111;border-bottom-left-radius:4px}"
      + ".mr-chat-input-wrap{padding:10px 12px;border-top:1px solid #eef2f7;background:#fff;display:flex;flex-direction:column;gap:8px}"
      + ".mr-chat-warning{color:#c91d2e;font:12px Arial,sans-serif;min-height:14px}"
      + ".mr-chat-row{display:flex;gap:8px}"
      + ".mr-chat-input{flex:1;border:1px solid #d6dbe5;border-radius:10px;padding:10px 12px;font:14px Arial,sans-serif;outline:none}"
      + ".mr-chat-send{background:#0066cc;color:#fff;border:none;border-radius:10px;padding:10px 14px;font:600 13px Arial,sans-serif;cursor:pointer}"
      + ".mr-loading{display:inline-flex;gap:4px;align-items:center}"
      + ".mr-dot{width:6px;height:6px;border-radius:50%;background:#6b7280;animation:mrBlink 1.2s infinite ease-in-out}"
      + ".mr-dot:nth-child(2){animation-delay:.2s}.mr-dot:nth-child(3){animation-delay:.4s}"
      + "@keyframes mrBlink{0%,80%,100%{opacity:.2;transform:translateY(0)}40%{opacity:1;transform:translateY(-2px)}}"
      + "@media (max-width:520px){.mr-chat-panel{right:10px;left:10px;bottom:78px;width:auto;height:70vh}.mr-chat-btn{right:12px;bottom:12px}}";

    var style = document.createElement("style");
    style.type = "text/css";
    style.textContent = css;
    document.head.appendChild(style);
  }

  function createNode(tag, className, text) {
    var el = document.createElement(tag);
    if (className) el.className = className;
    if (typeof text === "string") el.textContent = text;
    return el;
  }

  function addMessage(text, role) {
    var msg = createNode("div", "mr-msg " + (role === "user" ? "mr-msg-user" : "mr-msg-ai"));
    msg.textContent = text;
    messagesEl.appendChild(msg);
    messagesEl.scrollTop = messagesEl.scrollHeight;
  }

  function setLoading(active) {
    if (active) {
      sendBtn.disabled = true;
      inputEl.disabled = true;
      var loading = createNode("div", "mr-msg mr-msg-ai");
      loading.id = "mr-loading-msg";
      if (state.mode === "review" || state.mode === "consensus") {
        loading.appendChild(
          createNode("div", null, "Analyzing papers... this may take 1-2 minutes")
        );
      }
      var spinner = createNode("span", "mr-loading");
      spinner.innerHTML = '<span class="mr-dot"></span><span class="mr-dot"></span><span class="mr-dot"></span>';
      loading.appendChild(spinner);
      messagesEl.appendChild(loading);
      messagesEl.scrollTop = messagesEl.scrollHeight;
      return;
    }
    sendBtn.disabled = false;
    inputEl.disabled = false;
    var old = document.getElementById("mr-loading-msg");
    if (old && old.parentNode) old.parentNode.removeChild(old);
  }

  function hasPHI(text) {
    var v = String(text || "");
    for (var key in PHI_PATTERNS) {
      if (Object.prototype.hasOwnProperty.call(PHI_PATTERNS, key) && PHI_PATTERNS[key].test(v)) {
        return true;
      }
    }
    return false;
  }

  function getAuthHeaders() {
    return {
      "Content-Type": "application/json"
    };
  }

  function normalizeReply(payload) {
    if (!payload) return "";
    if (typeof payload.answer === "string") return payload.answer;
    if (payload.reply && typeof payload.reply.review_text === "string") return payload.reply.review_text;
    if (payload.reply && typeof payload.reply.verdict === "string") return "Verdict: " + payload.reply.verdict + " (" + payload.reply.confidence_pct + "%)";
    if (Array.isArray(payload.results)) return payload.results.map(function (r, i) { return (i + 1) + ". " + (r.title || "Untitled"); }).join("\n");
    if (payload.reply && payload.reply.citations && Array.isArray(payload.reply.citations)) return payload.reply.citations.join("\n");
    return typeof payload.message === "string" ? payload.message : JSON.stringify(payload);
  }

  async function sendMessage() {
    warningEl.textContent = "";
    var text = inputEl.value.trim();
    if (!text) return;
    if (hasPHI(text)) {
      warningEl.textContent = "Potential PHI detected in your input. Please remove identifying information.";
      return;
    }

    if (
      state.mode === "citation" &&
      (!state.lastSearchResults || state.lastSearchResults.length === 0)
    ) {
      addMessage(
        "Please run a PubMed search first, then switch to Generate Citations to format the results.",
        "ai"
      );
      return;
    }

    addMessage(text, "user");
    inputEl.value = "";
    setLoading(true);

    try {
      if (!API_BASE) throw new Error("Missing MEDRESEARCH_API_URL");

      var body = {
        question: text,
        mode: state.mode,
        session_id: sessionId,
        chat_history: []
      };

      if (state.mode === "citation") {
        body.papers = state.lastSearchResults || [];
        body.style = citationStyleEl.value;
      }

      const controller = new AbortController();
      const timeoutId = setTimeout(() => controller.abort(), 120000);

      var res = await fetch(API_BASE + "/api/chat", {
        method: "POST",
        headers: getAuthHeaders(),
        body: JSON.stringify(body),
        signal: controller.signal
      }).finally(() => clearTimeout(timeoutId));

      if (res.status === 400) {
        const errData = await res.json();
        addMessage(errData.message || "This file could not be uploaded.", "ai");
        return;
      }
      if (res.status === 401) {
        addMessage("Something went wrong. Please try again.", "ai");
        return;
      }
      if (!res.ok) {
        addMessage("Something went wrong. Please try again.", "ai");
        return;
      }

      var data = await res.json();
      if (Array.isArray(data.results)) {
        state.lastSearchResults = data.results;
      }
      var out = normalizeReply(data);
      addMessage(out, "ai");
      state.chatHistory.push({ question: text, answer: out });
    } catch (e) {
      addMessage("Something went wrong. Please try again.", "ai");
    } finally {
      setLoading(false);
    }
  }

  async function uploadPdf(file) {
    if (!file) return;
    warningEl.textContent = "";
    setLoading(true);
    try {
      var form = new FormData();
      form.append("file", file);
      form.append("session_id", sessionId);

      const controller = new AbortController();
      const timeoutId = setTimeout(() => controller.abort(), 120000);

      var res = await fetch(API_BASE + "/api/pdf/upload", {
        method: "POST",
        headers: {},
        body: form,
        signal: controller.signal
      }).finally(() => clearTimeout(timeoutId));

      if (res.status === 400) {
        addMessage("Your message contains protected health information. Please remove identifying details.", "ai");
        return;
      }
      if (res.status === 401) {
        addMessage("Something went wrong. Please try again.", "ai");
        return;
      }
      if (!res.ok) {
        addMessage("Something went wrong. Please try again.", "ai");
        return;
      }
      var data = await res.json();
      if (data && data.session_id) {
        sessionId = data.session_id;
        sessionStorage.setItem(SESSION_KEY, sessionId);
      }
      addMessage("PDF uploaded successfully. You can now ask questions about it.", "ai");
    } catch (e) {
      addMessage("Something went wrong. Please try again.", "ai");
    } finally {
      setLoading(false);
      pdfUploadEl.value = "";
    }
  }

  injectStyles();

  var btn = createNode("button", "mr-chat-btn");
  btn.type = "button";
  btn.innerHTML = '<span aria-hidden="true">💬</span><span>Research Assistant</span>';

  var panel = createNode("div", "mr-chat-panel");
  var header = createNode("div", "mr-chat-header", "MedResearch Ninja AI");
  var closeBtn = createNode("button", "mr-chat-close", "×");
  closeBtn.type = "button";
  header.appendChild(closeBtn);

  var tools = createNode("div", "mr-chat-tools");
  var modeSelect = createNode("select", "mr-chat-select");
  MODES.forEach(function (m) {
    var opt = document.createElement("option");
    opt.value = m.value;
    opt.textContent = m.label;
    modeSelect.appendChild(opt);
  });

  var pdfUploadEl = createNode("input", "mr-chat-upload");
  pdfUploadEl.type = "file";
  pdfUploadEl.accept = "application/pdf,.pdf";

  var citationStyleEl = createNode("select", "mr-chat-select");
  citationStyleEl.style.maxWidth = "40%";
  ["APA", "MLA", "Vancouver"].forEach(function (s) {
    var opt = document.createElement("option");
    opt.value = s;
    opt.textContent = s;
    citationStyleEl.appendChild(opt);
  });
  citationStyleEl.style.display = "none";

  tools.appendChild(modeSelect);
  tools.appendChild(citationStyleEl);
  tools.appendChild(pdfUploadEl);

  var messagesEl = createNode("div", "mr-chat-messages");

  var inputWrap = createNode("div", "mr-chat-input-wrap");
  var warningEl = createNode("div", "mr-chat-warning");
  var row = createNode("div", "mr-chat-row");
  var inputEl = createNode("input", "mr-chat-input");
  inputEl.type = "text";
  inputEl.placeholder = "Ask a research question...";
  var sendBtn = createNode("button", "mr-chat-send", "Send");
  sendBtn.type = "button";
  row.appendChild(inputEl);
  row.appendChild(sendBtn);
  inputWrap.appendChild(warningEl);
  inputWrap.appendChild(row);

  panel.appendChild(header);
  panel.appendChild(tools);
  panel.appendChild(messagesEl);
  panel.appendChild(inputWrap);
  document.body.appendChild(btn);
  document.body.appendChild(panel);

  function refreshModeUI() {
    var isPdf = state.mode === "pdf_chat";
    var isCitation = state.mode === "citation";
    pdfUploadEl.style.display = isPdf ? "inline-block" : "none";
    citationStyleEl.style.display = isCitation ? "inline-block" : "none";
    state.chatHistory = [];
    messagesEl.innerHTML = "";
    warningEl.textContent = "";
  }

  btn.addEventListener("click", function () {
    state.open = !state.open;
    panel.style.display = state.open ? "flex" : "none";
  });
  closeBtn.addEventListener("click", function () {
    state.open = false;
    panel.style.display = "none";
  });
  modeSelect.addEventListener("change", function () {
    state.mode = modeSelect.value;
    refreshModeUI();
  });
  sendBtn.addEventListener("click", sendMessage);
  inputEl.addEventListener("keydown", function (e) {
    if (e.key === "Enter") {
      e.preventDefault();
      sendMessage();
    }
  });
  pdfUploadEl.addEventListener("change", function (e) {
    var f = e.target.files && e.target.files[0];
    uploadPdf(f);
  });

  refreshModeUI();
})();
