function solve(args) {
  var arrayA = args[0];
  var arrayB = args[1];
  var found = false;
  var len = 0;

  if (arrayA.length >= arrayB.length) {
    len = arrayB.length;
  } else {
    len = arrayA.length;
  }

  for (var index = 0; index < len; index += 1) {
    if (arrayA[index] < arrayB[index]) {
      console.log(arrayA);
      found = true;
      break;
    } else if (arrayA[index] > arrayB[index]) {
      console.log(arrayB);
      found = true;
      break;
    }
  }

  if (!found) {
    if (arrayA.length >= arrayB.length) {
      console.log(arrayB);
    } else {
      console.log(arrayA);
    }
  }
}