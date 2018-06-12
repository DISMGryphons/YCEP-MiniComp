#!/bin/bash
docker build -t web-search .
docker run --restart always -d -p 8002:80 --name web-search web-search
docker start web-search
