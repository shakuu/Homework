// jshint  esversion: 6

function ReverseString(str) {
  var input = String(str);
  var output = '';
  var len = input.length;

  for (var index = len - 1; index >= 0; index -= 1) {
    output += input[index];
  }

  return output;
}