function solve(args) {
  var array = (args + '').split('\n').map(Number),
    max = 0,
    counter = 1,
    prev = array[0],
    len, index, element;

  len = array.length;
  for (index = 1; index < len; index += 1) {
    element = array[index];

    if (element > prev) {
      counter += 1;
    } else {
      
      if (counter > max) {
        max = counter;
      }

      counter = 1;
    }

    prev = element;
  }

  if (counter > 1) {
    if (counter > max) {
      max = counter;
    }
  }

  console.log(max);
}