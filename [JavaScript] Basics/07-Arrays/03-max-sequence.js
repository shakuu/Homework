function solve(args) {
  var array = args;

  var counter = 1;
  var max = 0;
  var prev = array[1];

  var len = array.length;
  for (var index = 1; index < len; index += 1) {
    var element = array[index];
    console.log(element);

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

  console.log(max);
}



