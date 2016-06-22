function solve(args) {
  var input = (args + '').split('\n').map(Number),
    len, i, j, output = [], min, minIndex, temp;

    input.splice(0, 1);

  len = input.length;
  for (i = 0; i < len; i += 1) {
    min = input[i];

    for (j = i + 1; j < len; j += 1) {

      if (input[j] < min) {

        min = input[j];
        minIndex = j;
      }
    }

    temp = input[i];
    input[i] = input[minIndex];
    input[minIndex] = temp;
  }

  console.log();
  for (i = 0; i < len; i += 1) {
    console.log(input[i]);
  }
}

// solve( [ '6\n3\n4\n1\n5\n2\n6' ]);