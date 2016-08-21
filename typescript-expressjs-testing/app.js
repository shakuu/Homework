var express = require('express');
var app = express();
var path = require('path')
var request = require("request");

app.use(express.static('public'));

app.get('/', function (req, res) {
    res.sendFile(path.join(__dirname + '/index.html'));
});

app.listen(3000, function () {
    console.log('Example app listening on port 3000!');
});

app.get('/test', function (req, res) {
    request("http://localhost:3000/secret", function (error, response, body) {
        res.send(body);
    });
});

app.get('/secret', function (req, res) {
    res.sendFile(path.join(__dirname + '/test.html'));
});

app.get('/test.html', function (req, res) {
    res.sendFile(path.join(__dirname + '/test.html'));
});