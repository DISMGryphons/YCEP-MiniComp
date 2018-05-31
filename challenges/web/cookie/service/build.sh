#!/bin/bash
docker build -t cookie .
docker run --restart always --memory 128M -d -p 8001:80 --name web-cookie cookie
docker start web-cookie