FROM ubuntu:latest

# Basic stuff
RUN apt update
RUN apt upgrade -y
RUN apt install -y curl sudo gnupg iptables net-tools
RUN curl -sL https://deb.nodesource.com/setup_8.x | sudo -E bash -
RUN apt install -y nodejs

# Files
COPY server.js /home/nodeGW/
COPY trafficRedirect.sh /home/nodeGW/

# User
RUN useradd -m nodeGW
RUN mkdir /home/nodeGW/logs
RUN chmod -R 750 /home/nodeGW
RUN chmod -R 770 /home/nodeGW/logs
RUN chown -R root:nodeGW /home/nodeGW
USER nodeGW
ENV home /home/nodeGW
WORKDIR /home/nodeGW

# Port Expose
EXPOSE 8000

# Final shitz
CMD ["node", "server.js"]
