-- Revert bddexample:messages from pg

BEGIN;

DROP TABLE bddexample.messages;

COMMIT;
