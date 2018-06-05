#!/usr/bin/env node

const HOST = '127.0.0.1';
const PORT = '8000'

const net = require('net');
const fs = require('fs');

var currFileName = 'server.log';
var logNumber = 0;

const server = net.createServer((socket) => {
    const remoteAddress = socket.remoteAddress;
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
    socket.write('MC{TH#_W4LL_15_D0WN}');
});
