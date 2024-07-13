-- Deploy bddexample:messages to pg
-- requires: appschema

BEGIN;

CREATE TABLE bddexample.messages (
  id SERIAL PRIMARY KEY,
  message TEXT NOT NULL
);

COMMIT;
