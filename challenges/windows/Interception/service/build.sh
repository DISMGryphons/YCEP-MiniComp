#!/bin/sh
docker build . -t win-interception
docker run -d --restart always --memory 128M -p 5000:8000 --name win-interception win-interception
docker start win-interception
