function solve(args) {
  var input = args
    .map(Number),
    step = 4,
    sizes = [];

  function distance(index) {
    var arr = input;

    var a = Math.abs(arr[index] - arr[index + 2]);
    var b = Math.abs(arr[index + 1] - arr[index + 3]);

    return Math.sqrt((a * a) + (b * b));
  }

  for (var i = 0; i < input.length; i += step) {
    sizes.push(+distance(i));
  }


  var output;
  if (sizes[0] + sizes[1] > sizes[2] && sizes[1] + sizes[2] > sizes[0] && sizes[0] + sizes[2] > sizes[1]) {
    output = 'Triangle can be built';
  } else {
    output = 'Triangle can not be built';
  }

  console.log(
    sizes
      .map(Number)
      .map(
      function (a) {
        return a.toFixed(2)
      })
      .join('\n'));
  console.log(output);
}

solve(['5', '6', '7', '8', '1', '2', '3', '4', '9', '10', '11', '12']);