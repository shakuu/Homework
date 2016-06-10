//jshint esversion:6

function SubstringCount(text, str) {
  let parse = String(text)
    .toLowerCase();

  let find = String(str)
    .toLowerCase();

  let counter = 0;

  let index = parse.indexOf(find);
  while (index >= 0) {
    counter += 1;
    index = parse.indexOf(find, index + 1);
  }

  return counter;
}