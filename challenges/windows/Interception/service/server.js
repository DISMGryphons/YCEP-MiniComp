#!/usr/bin/env node

const HOST = '0.0.0.0';
const PORT = '8000'

const net = require('net');
const fs = require('fs');

var currFileName = './logs/server.log';
var logNumber = 0;

const server = net.createServer((socket) => {
    const remoteAddress = socket.remoteAddress;
    socket.on('error', (err) => {
        socket.destroy();
        // Does nothing
    });

    // Logging
    fs.appendFile(currFileName, 'Connection started from ' + remoteAddress + '\n', (err) => {
        if (err) throw err;
        const fileStats = fs.statSync(currFileName);
        if ((fileStats.size / 1000000.0) >= 100) {
            currFileName += '.' + ++logNumber;
        }
    });
}).listen(PORT, HOST);

server.on('listening', () => {
    console.log('Server successfully started at ' + HOST + ':' + PORT + '!');
});

server.on('connection', (socket) => {
    socket.setEncoding('ascii');
    socket.on('data', (data) => {
        console.log("Client got flag!");
        socket.write('MC{M155I0N_1MP0S51BL3}');
        socket.end();
        socket.destroy();
    });
});
