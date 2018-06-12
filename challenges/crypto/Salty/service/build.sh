#!/bin/bash
docker build -t salty .
docker run --restart always --memory 128M -d -p 7000:80 --name crypto-salty salty
docker start crypto-salty