function solve(args) {
  var input = (args + '').split('\n').map(Number),
  // var input = [].concat(args).map(Number),
    checked = [],
    i, j, len,
    counter = 0, max = 0, maxNum = 0;

  input.splice(0, 1);
  len = input.length;

  for (i = 0; i < len; i += 1) {

    if (checked.indexOf(input[i]) >= 0) {
      continue;
    }

    for (j = 0; j < len; j += 1) {
      if (input[j] === input[i]) {
        counter += 1;
      }
    }

    if (max < counter) {
      max = counter;
      maxNum = input[i];
    }

    counter = 0;
    checked.push(input[i]);
  }

  console.log(maxNum + ' (' + max + ' times)');
}

// solve(['13', '4', '1', '1', '4', '2', '3', '4', '4', '1', '2', '4', '9', '3']);