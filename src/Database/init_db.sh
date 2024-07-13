#!/bin/bash

psql -U postgres -c "CREATE DATABASE bddexample;"
cd /database
sqitch deploy -u postgres
pg_dump -U postgres --format custom bddexample > /tmp/dump.pgdata
touch /tmp/dump_done
