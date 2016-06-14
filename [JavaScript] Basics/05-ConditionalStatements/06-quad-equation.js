function QuadraticEquation() {
  var numA = Number(document.getElementById("a").value);
  var numB = Number(document.getElementById("b").value);
  var numC = Number(document.getElementById("c").value);

  var numD = (numB * numB) - (4 * numA * numC);

  if (numD < 0) {
    jsConsole.writeLine("no real roots");
  }

  else if (numD == 0) {
    var output = -numB / (2 * numA);
    jsConsole.writeLine(output);
  }
  
  else if (numD > 0) {
    var sqrtD = Math.sqrt(numD);
    
    var output1 = (-numB + sqrtD) / (2 * numA);
    var output2 = (-numB - sqrtD) / (2 * numA);
    
    jsConsole.writeLine(output2 + " " + output1);
  }
}