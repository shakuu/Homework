function solve(args) {
  var numA = +args[0];
  var numB = +args[1];
  var numC = +args[2];

  var isZero = false;
  var negativeCounter = 0;

  if (numA === 0 ||
    numB === 0 ||
    numC === 0) {
    isZero = true;
  }

  if (numA < 0) {
    negativeCounter += 1;
  }

  if (numB < 0) {
    negativeCounter += 1;
  }

  if (numC < 0) {
    negativeCounter += 1;
  }

  if (isZero) {
    console.log('0');
  }
  else {
    if (negativeCounter % 2 === 0) {
      console.log('+');
    }
    else {
      console.log('-');
    }
  }
}

function solveagain(args) {
  var negativeCounter = 0;
  var zeroCounter = 0;

  var len = args.length;
  for (let index = 0; index < len; index += 1) {
    
    if (+args[index] < 0) {
      negativeCounter += 1;
    }
    
     else if (+args[index] === 0) {
      zeroCounter += 1;
    }
  }

  if (zeroCounter === len) {
    
    console.log('0');
  }
  else {

    if (negativeCounter % 2 === 0) {
      console.log('+');
    }
    else {
      console.log('-');
    }
  }
}
solveagain(['0', '0', '0']);