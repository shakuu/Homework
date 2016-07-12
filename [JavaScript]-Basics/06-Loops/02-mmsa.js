function solve(args) {
  var len = args.length;

  var min = +args[0];
  var max = +args[0];
  var sum = +args[0];
  var avg = 0;

  for (var i = 1; i < len; i += 1) {
    // Min
    if (min > +args[i]) {
      min = +args[i];
    }
    // Max
    if (max < +args[i]) {
      max = +args[i];
    }
    // Sum
    sum += +args[i];
  }

  avg = sum / len;

  // Output min, max, sum, avg
  console.log('min=' + min.toFixed(2));
  console.log('max=' + max.toFixed(2));
  console.log('sum=' + sum.toFixed(2));
  console.log('avg=' + avg.toFixed(2));
}

solve(['3', '2', '5', '1']);