//jshint esversion: 6
'use strict()';

function stringFormat() {
  let format = String(arguments[0]);
  let len = format.length;
  let output = '';

  let isToken = false;
  let token = '';

  for (let index = 0; index < len; index += 1) {
    let chr = format[index];

    if (chr === '{') {
      isToken = true;
    } else if (chr === '}') {
      // replace
      let insert = arguments[Number(token) + 1];
      output += insert;
      isToken = false;
      token = '';
    } else if (isToken) {
      token += chr;
    } else {
      output += chr;
    }
  }

  return output;
}

let frmt = '{0}, {1}, {0} text {2}';
let str = stringFormat(frmt, 1, 'Pesho', 'Gosho');
console.log(str);

str = stringFormat('Hello {0}!', 'Peter');
console.log(str);