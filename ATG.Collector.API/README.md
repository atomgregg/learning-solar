# Documentation for a .NET WebAPI

## Purpose

This API will serve historical measurement data from a PostgreSQL database.
The database and the API will both be run as docker containers on a Raspberry Pi.
This is intended only as a learning and experimentation experience.

## Contents

- [Building](#instructions-for-building)
- [Running](#instructions-for-running)

## Instructions for building

```bash
docker buildx build -t atomgregg/atg-api:v0.1 --platform linux/arm64,linux/arm,linux/amd64 .
docker buildx build --pull --push -t atomgregg/atg-api:v0.1 -f Dockerfile.net8preview.raspberrypi --platform linux/arm64,linux/arm,linux/amd64 .
```

## Instructions for running

```bash
# get the latest image
docker pull atomgregg/atg-api:v0.1

# stop any existing container
docker container stop atg-api

# start the new one
docker run -d --rm -p 5000:80 -p 5001:443 --env ASPNETCORE_URLS="https://+;http://+" --env ASPNETCORE_HTTPS_PORT=5001 --env=DOTNET_RUNNING_IN_CONTAINER=true --env ASPNETCORE_Kestrel__Certificates__Default__Path=/https/atg-api.crt -e ASPNETCORE_Kestrel__Certificates__Default__KeyPath=/https/atg-api.key -v /home/piadmin/atg-api:/https/ --name atg-api atomgregg/atg-api:v0.1

# connect to the network
docker network connect atg-network atg-api