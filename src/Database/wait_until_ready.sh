#!/bin/sh

until [ -f /tmp/dump_done ]; do
  sleep 1
done
