function solve(args) {
  var lines = (args[0] + '')
    .split('\n'),
    numbers = lines[1]
      .split(' ')
      .map(Number)
      .filter(function (a) {
        return +a === +lines[2];
      }).length;
  console.log(numbers);
}

solve(['8\n28 6 21 6 -7856 73 73 -56\n73'])