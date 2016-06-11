//jshint esversion: 6
'use strict()';

function Replace() {
  let output = input.replace(/ /g, nbsp);
  console.log(output);
}

let input = process.argv[2]
let nbsp = '&nbsp;';

Replace();

