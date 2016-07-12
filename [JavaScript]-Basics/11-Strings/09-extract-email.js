//jshint esversion: 6
'use strict()';
let input = process.argv[2];

function ExtractEmail() {
  let parse = String(input)
    .split(' ')
    .map(String);

  let output = [];

  let len = parse.length;
  for (let index = 0; index < len; index += 1) {
    if (parse[index].indexOf('@') >= 0) {
      output.push(parse[index]);
    }
  }

  console.log(output);
}

ExtractEmail();

