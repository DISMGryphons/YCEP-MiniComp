FROM node:alpine

# Basic stuff
RUN apk update
RUN apk upgrade

# Files
COPY server.js /home/nodeINT/

# User
RUN adduser -D nodeINT
RUN mkdir /home/nodeINT/logs
RUN chmod -R 750 /home/nodeINT
RUN chmod -R 770 /home/nodeINT/logs
RUN chown -R root:nodeINT /home/nodeINT
USER nodeINT
ENV home /home/nodeINT
WORKDIR /home/nodeINT

# Port Expose
EXPOSE 8000

# Final shitz
CMD ["node", "server.js"]
