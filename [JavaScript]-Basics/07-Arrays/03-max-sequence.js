function solve(args) {
  var array = (args + '').split('\n').map(Number),
    counter = 1,
    max = 0,
    prev = +array[0],
    index, len, element;

  len = array.length;
  for (index = 1; index < len; index += 1) {
    element = +array[index];

    if (element === prev) {
      counter += 1;
    }
    else {
      if (counter > max) {
        max = counter;
      }

      counter = 1;
    }

    prev = element;
  }

  if (counter > max) {
    max = counter;
  }

  console.log(max);
}



