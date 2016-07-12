function solve(args) {
  var numbers = args[1]
      .split(' ')
      .map(Number)
      .filter(function (a) {
        return +a === +args[2];
      }).length;
  console.log(numbers);
}

solve([ '8', '28 6 21 6 -7856 73 73 -56', '73' ]);