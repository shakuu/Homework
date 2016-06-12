//jshint esversion: 6
'use strict()';

let input = process.argv[2];
let output = [].map(String);

function Check(arg) {
  let word = String(arg);
  let len = word.length;

  if (len < 2) {
    return false;
  }
  else if (len % 2 == 1) {
    return false;
  }
  else {
    for (let index = 0; index < len / 2; index += 1) {
      if (word[index] != word[len - 1 - index]) {
        return false;
      }
    }

    return true;
  }
}

function Palindromes() {
  let words = String(input).split(' ');
  let checked = [].map(String);

  let len = words.length;
  for (let index = 0; index < len; index += 1) {
    let word = words[index];

    if (checked.indexOf(word) < 0) {
      if (Check(word)) {
        output.push(word);
      }
      checked.push(word);
    }
  }
}

Palindromes();
console.log(output);
