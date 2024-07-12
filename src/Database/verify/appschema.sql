-- Verify bddexample:appschema on pg

BEGIN;

SELECT pg_catalog.has_schema_privilege('bddexample', 'usage');

ROLLBACK;
