#!/bin/bash
set -e

# Wait until the PostgreSQL service is healthy
until dotnet ef database update; do
  echo "Waiting for PostgreSQL to be available..."
  sleep 5
done

# Run the application
exec "$@"