#!/bin/bash

until [ -f /tmp/dump_done ]; do
  sleep 1
done
