-- Revert bddexample:set_message from pg

BEGIN;

DROP FUNCTION bddexample.set_message;

COMMIT;
