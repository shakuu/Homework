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
     console.log('x1=x2='+ output.toFixed(2));
  }
  
  else if (numD > 0) {
    var sqrtD = Math.sqrt(numD);
    
    var output1 = (-numB + sqrtD) / (2 * numA);
    var output2 = (-numB - sqrtD) / (2 * numA);
    
    if (output2 < output1) {
      temp = output1;
      output1 = output2;
      output2 = temp;
    }

    console.log('x1=' + output1.toFixed(2) + "; x2=" + output2.toFixed(2));
  }
}

solve(['5', '2', '8']);
