#!/bin/sh
docker build . -t net-greatwall
docker run -d --restart always --memory 128M -p 8000:8000 --name net-greatwall net-greatwall
docker start net-greatwall
