//jshint esversion: 6
'use strict()';

function ExtractURL() {
  let parse = String(input);
  let index = 0;
  let len = protocolSeparator.length;

  index = parse.indexOf(protocolSeparator);
  protocol = parse.substr(0, index);

  len = index + len;
  index = parse.indexOf(serverSeparator, len);

  server = parse.substr(len, index - len);
  resource = parse.substr(index);

  console.log('protocol: ' + protocol);
  console.log('server:   ' + server);
  console.log('resource: ' + resource);
}

let input = process.argv[2];

let protocolSeparator = '://';
let serverSeparator = '/';

let protocol = '';
let server = '';
let resource = '';

ExtractURL();