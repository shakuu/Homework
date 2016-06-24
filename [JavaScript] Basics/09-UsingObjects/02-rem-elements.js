function solve(args) {
  var output = (args[0] + '')
    .split(' ')
    .filter(function (a) {
      return !(a === output[0]);
    });
console.log(output);
}

solve([ '1', '2', '3', '2', '1', '2', '3', '2' ]);