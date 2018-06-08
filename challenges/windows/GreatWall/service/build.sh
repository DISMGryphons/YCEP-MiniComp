#!/bin/sh
docker build . -t win-greatwall
docker run -d --restart always --memory 128M -p 5050-5060:8000-8010 --cap-add=NET_ADMIN --name win-greatwall win-greatwall
docker start win-greatwall
sudo docker exec -u 0 -it win-greatwall /bin/sh -c ./trafficRedirect.sh
