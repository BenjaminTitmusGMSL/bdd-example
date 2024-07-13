-- Verify bddexample:messages on pg

BEGIN;

SELECT id, message
  FROM bddexample.messages
 WHERE FALSE;

ROLLBACK;
