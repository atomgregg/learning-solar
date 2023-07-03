# Documentation for a VueJS Web Application

## Purpose

This web application enables me to create an online presense, similar to a resume.
This resume, includes details about my experience, how to contact me, and some projects/blog posts show-casing some experiments or projects.
The website is run within a docker container, and is secured via SSL termination with certificates generated with CertBot/LetsEncrypt.

## Contents

- [Documentation for a VueJS Web Application](#documentation-for-a-vuejs-web-application)
  - [Purpose](#purpose)
  - [Contents](#contents)
  - [Instructions for building](#instructions-for-building)
  - [Instructions for running](#instructions-for-running)
  - [Instructions for debugging](#instructions-for-debugging)

## Instructions for building

```bash
docker build -t atomgregg/atg-ui:v0.1 .
docker push atomgregg/atg-ui:v0.1
```

## Instructions for running

```bash
# get the latest image
docker pull atomgregg/atg-ui:v0.1

# stop any existing container
docker container stop atg-ui

# start the new one
docker run -p 80:80 -p 443:443 -v /home/piadmin/atg-ui/certbot/www:/var/www/certbot -v /home/piadmin/atg-ui/certbot/conf:/etc/letsencrypt --name atg-ui -d --rm atomgregg/atg-ui:v0.1

# connect to the network
docker network connect atg-network atg-ui
```

## Instructions for debugging

```bash
docker exec -i -t atg-ui /bin/bash
```