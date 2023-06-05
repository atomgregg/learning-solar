# Use the latest PostgreSQL image as the base
FROM postgres:latest

# initialize the database and tables
COPY init_postgres.sql /docker-entrypoint-initdb.d/

# Set environment variables for PostgreSQL
#ENV POSTGRES_DB atg
ENV POSTGRES_USER postgres
ENV POSTGRES_PASSWORD password

# Expose the PostgreSQL default port (5432)
EXPOSE 5432
