#!/bin/sh
docker build -t raw-source .
docker run --restart always --memory 128M -d -p 8000:80 --name web-raw-source raw-source
docker start web-raw-source
