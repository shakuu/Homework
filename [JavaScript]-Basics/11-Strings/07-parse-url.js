function solve(args) {
  var protocolSeparator = '://';
  var serverSeparator = '/';
  var parse = args[0] + '';
  var index = 0;
  var len = protocolSeparator.length;

  var protocol = '';
  var server = '';
  var resource = '';


  index = parse.indexOf(protocolSeparator);
  protocol = parse.substr(0, index);

  len = index + len;
  index = parse.indexOf(serverSeparator, len);

  server = parse.substr(len, index - len);
  resource = parse.substr(index);

  console.log('protocol: ' + protocol);
  console.log('server: ' + server);
  console.log('resource: ' + resource);
}

test1 = ([ 'http://telerikacademy.com/Courses/Courses/Details/212' ]);

solve(test1);