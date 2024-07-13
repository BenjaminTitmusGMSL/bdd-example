-- Deploy bddexample:set_message to pg
-- requires: messages

BEGIN;

CREATE OR REPLACE FUNCTION bddexample.set_message(message TEXT) RETURNS VOID AS
$$
BEGIN
  INSERT INTO bddexample.messages (message) VALUES (message);
END
$$
  LANGUAGE 'plpgsql' STRICT;

COMMIT;
