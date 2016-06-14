var datain = document
  .getElementById('data-in');

var gobtn = document
  .getElementById('go')
  .addEventListener('click', function () {
    var input = datain.value;
    EnglishDigit(input);
  });

function EnglishDigit(args) {
  var digits = [
    "zero",
    "one",
    "two",
    "three",
    "four",
    "five",
    "six",
    "seven",
    "eight",
    "nine"];

  var length = args.length;

  var word = digits[args[length-1]];

  console.log(word);
}