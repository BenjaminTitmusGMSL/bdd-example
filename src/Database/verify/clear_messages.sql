-- Verify bddexample:clear_messages on pg

BEGIN;

SELECT has_function_privilege(
  'bddexample.clear_messages()',
  'execute');

ROLLBACK;
