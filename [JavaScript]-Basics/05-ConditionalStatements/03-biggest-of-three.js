function solve(args) {
  var numA = +args[0];
  var numB = +args[1];
  var numC = +args[2];

  if (numA >= numB) {
    if (numA >= numC) {
      console.log(numA);
    }
    else {
      console.log(numC);
    }
  }
  else {
    if (numB >= numC) {
      console.log(numB);
    }
    else {
      console.log(numC);
    }
  }
}

solve(['0', '-2', '2.5']);

