function solve(args) {
  var numbers = (args + '').split(' ').map(Number);
  max = numbers.reduce(function (a, b) {
    return a >= b ? a : b;
  });
  console.log(max);
}

solve('5 6 4');