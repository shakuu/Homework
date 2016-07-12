function solve(args) {
  var numA = +args[0];
  var numB = +args[1];
  var numC = +args[2];
  var temp = 0;

  while (!(numA >= numB && numB >= numC)) {
    if (numA < numB) {
      temp = numA;
      numA = numB;
      numB = temp;
    }

    if (numB < numC) {
      temp = numC;
      numC = numB;
      numB = temp;
    }
  }
  
  console.log(numA + " " + numB + " " + numC);
}

solve(['2', '5', '10']);
