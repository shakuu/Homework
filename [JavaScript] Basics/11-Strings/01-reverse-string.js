// jshint  esversion: 6

function ReverseString(str) {
  let input = String(str);
  let output = '';
  let len = input.length;

  for (let index = len - 1; index >= 0; index -= 1) {
    output += input[index];
  }

  return output;
}