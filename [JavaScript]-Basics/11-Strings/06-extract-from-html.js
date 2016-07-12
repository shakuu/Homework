function solve(args) {
  var input = args,
    result = '';

  for (var i in input) {
    var parse = input[i].trim();
    var len = parse.length;
    for (var index = 0; index < len; index += 1) {
      var chr = parse[index];

      if (chr === '<') {
        isTag = true;
      }
      else if (chr === '>') {
        isTag = false;
      }
      else if (!isTag) {
        result += chr;
      }
    }
  }
  
  console.log(result);
}

var test1 = [
  '<html>',
  '  <head>',
  '    <title>Sample site</title>',
  '  </head>',
  '  <body>',
  '    <div>text',
  '      <div>more text</div>',
  '      and more...',
  '    </div>',
  '    in body',
  '  </body>',
  '</html>'
];

solve(test1);