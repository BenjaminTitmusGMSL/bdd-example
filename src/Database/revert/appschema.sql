-- Revert bddexample:appschema from pg

BEGIN;

DROP SCHEMA bddexample;

COMMIT;
