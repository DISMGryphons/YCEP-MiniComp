#!/bin/sh
docker build . -t win-greatwall
docker run -d --restart always --memory 128M -p 9050:8000 -p 9437:8000 -p 9928:8000 --name win-greatwall win-greatwall
docker start win-greatwall
