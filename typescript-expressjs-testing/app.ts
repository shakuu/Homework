declare function require(name: string);

interface animal {
    name: string,
    age: number
}

var express = require('express');
var app = express();
var path = require('path')

app.use(express.static('public'));

app.get('/', function (req, res) {
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.open("GET", 'google.com, false); // false for synchronous request
    xmlHttp.send(null);
    res.send(xmlHttp.responseText);

    res.sendFile(path.join(__dirname + '/index.html'));
});

app.listen(3000, function () {
    console.log('Example app listening on port 3000!');
});

