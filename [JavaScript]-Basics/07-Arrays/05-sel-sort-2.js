function solve(args) {
  var input = (args + '').split('\n').map(Number),
    len, i, j, temp;

  len = input.length;
  for (i = 1; i < len; i += 1) {
    for (j = i + 1; j < len; j += 1) {
      if (input[j] < input[i]) {
        temp = input[i];
        input[i] = input[j];
        input[j] = temp;
      }
    }
  }

  console.log();
  input.splice(0, 1);
  console.log(input.join('\n'));
}