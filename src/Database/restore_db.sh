#!/bin/sh

psql -U postgres -c "CREATE DATABASE bddexample;"
pg_restore -U postgres --dbname=bddexample --single-transaction < /docker-entrypoint-initdb.d/dump.pgdata || exit 1
