from app.phi_scanner import scan_text
body = '{"question":"Does intermittent fasting improve insulin sensitivity?","mode":"consensus","session_id":"test-123","chat_history":[]}'
result = scan_text(body)
print('is_safe:', result['is_safe'])
print('violations:', result['violations'])
