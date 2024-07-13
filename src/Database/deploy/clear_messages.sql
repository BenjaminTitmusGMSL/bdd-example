-- Deploy bddexample:clear_messages to pg
-- requires: messages

BEGIN;

CREATE OR REPLACE FUNCTION bddexample.clear_messages() RETURNS VOID AS
$$
BEGIN
  TRUNCATE bddexample.messages;
END
$$
  LANGUAGE 'plpgsql';

COMMIT;
