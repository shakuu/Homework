function solve(args) {
  var numA = +args[0];
  var numB = +args[1];
  var numC = +args[2];
  
  var numD = (numB * numB) - (4 * numA * numC);

  if (numD < 0) {
   console.log("no real roots");
  }

  else if (numD === 0) {
    var output = -numB / (2 * numA);
     console.log(output);
  }
  
  else if (numD > 0) {
    var sqrtD = Math.sqrt(numD);
    
    var output1 = (-numB + sqrtD) / (2 * numA);
    var output2 = (-numB - sqrtD) / (2 * numA);
    
    console.log(output2 + " " + output1);
  }
}

solve(['5', '2', '8']);
