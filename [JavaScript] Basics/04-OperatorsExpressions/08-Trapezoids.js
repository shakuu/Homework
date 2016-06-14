function solve(args) {
  var x = Number(args[0]);
  var y = Number(args[1]);
  var h = Number(args[2]);

  var output = x + y;
  output /= 2;
  output *= h;

  console.log(output.toFixed(7));
}

solve(["8.5", '4.3', '2.7']);