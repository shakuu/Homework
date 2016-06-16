function solve(params) {
  var nk = params[0].split(' ').map(Number),
    numbers = params[1].split(' ').map(Number),
    result = 0;
  // Your solution here
  var left = 0;
  var right = 0;

  for (var run = 0; run < nk[1]; run += 1) {
    var newarray = new Array(nk[0]);
    for (var index = 0; index < nk[0]; index += 1) {

      if (index === 0) {
        left = numbers[nk[0] - 1];
        right = numbers[1];
      } else if (index === nk[0] - 1) {
        left = numbers[index - 1];
        right = numbers[0];
      } else {
        left = numbers[index - 1];
        right = numbers[index + 1];
      }

      if (numbers[index] === 0) {
        newarray[index] = Math.abs(left - right);
      } else if (numbers[index] % 2 === 0) {
        newarray[index] = left >= right ? left : right;
      } else if (numbers[index] === 1) {
        newarray[index] = left + right;
      } else if (numbers[index] % 2 === 1) {
        newarray[index] = Math.min(left, right);
      }
    }

    numbers = newarray;
  }

  for (var index = 0; index < nk[0]; index += 1) {
    result += numbers[index];
  }

  console.log(result);
}

var input = [];
input[0] = '10 10';
input[1] = '0 1 2 3 4 5 6 7 8 9';

solve(input)