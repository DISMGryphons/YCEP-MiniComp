FROM node:alpine

# Basic stuff
RUN apk update
RUN apk upgrade

# Files
COPY server.js /home/nodeGW/

# User
RUN adduser -D nodeGW
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
