FROM galien0xffffff/postgres-debugger:15 AS base
RUN apt --yes update \
    && apt --yes install sqitch

FROM base AS build
COPY ["src/Database", "/database"]
COPY ["src/Database/init_db.sh", "/docker-entrypoint-initdb.d/init_db.sh"]
ENV POSTGRES_HOST_AUTH_METHOD=trust
RUN nohup bash -c "docker-entrypoint.sh postgres &" \
    && database/wait_until_ready.sh

FROM galien0xffffff/postgres-debugger:15 AS final
COPY ["src/Database/restore_db.sh", "/docker-entrypoint-initdb.d/restore_db.sh"]
COPY --from=build ["/tmp/dump.pgdata", "/docker-entrypoint-initdb.d/dump.pgdata"]
