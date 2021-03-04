'use strict';

const portNumber = 8080;
const host = '0.0.0.0';

var express = require('express');
var app = express();

app.use('/', express.static(__dirname));
app.listen(portNumber, host);

console.log(`Currently hosting on http://${host}:${portNumber}`);