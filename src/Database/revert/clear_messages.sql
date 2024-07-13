-- Revert bddexample:clear_messages from pg

BEGIN;

DROP FUNCTION bddexample.clear_messages;

COMMIT;
