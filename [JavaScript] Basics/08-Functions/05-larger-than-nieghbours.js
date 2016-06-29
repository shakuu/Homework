function solve(args) {
  var lines = args[1]
    .split(' ')
    .map(Number)
    .filter(function (n, index, arr) {
      return (arr[index - 1] < n && n > arr[index + 1]);
    }).length;

  console.log(lines);
}

solve(['6', '-26 -25 -28 31 2 27']);