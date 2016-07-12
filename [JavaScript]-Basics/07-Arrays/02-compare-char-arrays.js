function solve(args) {
  var input = (args[0] + '').split('\n');
  var found = false;
  var len = 0;

  var arrayA = input[0];
  var arrayB = input[1];

  if (arrayA.length >= arrayB.length) {
    len = arrayB.length;
  } else {
    len = arrayA.length;
  }

  for (var index = 0; index < len; index += 1) {
    if (arrayA[index] < arrayB[index]) {
      console.log('<');
      found = true;
      break;
    } else if (arrayA[index] > arrayB[index]) {
      console.log('>');
      found = true;
      break;
    }
  }

  if (!found) {
    if (arrayA.length > arrayB.length) {
      console.log('>');
    } 
    else if (arrayA.length === arrayB.length) {
      console.log('=');
    }
    else {
      console.log('<');
    }
  }
}
