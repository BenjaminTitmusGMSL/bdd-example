-- Verify bddexample:set_message on pg

BEGIN;

SELECT has_function_privilege(
  'bddexample.set_message(text)',
  'execute');

ROLLBACK;
