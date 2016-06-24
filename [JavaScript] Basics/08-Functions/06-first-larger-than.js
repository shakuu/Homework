function solve(args) {
  var lines = (args[0] + '')
    .split('\n')[1]
    .split(' ')
    .map(Number);

  for (var i in lines) {
    if ((lines[+i - 1] < lines[+i] && lines[+i] > lines[+i + 1])) {
      console.log(i);
      return;
    }
  }

  console.log(lines);
}

solve(['6\n-26 -25 -28 31 2 27']);