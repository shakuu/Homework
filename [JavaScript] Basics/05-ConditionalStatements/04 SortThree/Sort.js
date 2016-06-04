
function Sort() {
  var numA = Number(document.getElementById("a").value);
  var numB = Number(document.getElementById("b").value);
  var numC = Number(document.getElementById("c").value);

  if (numA < numB) {
    numA ^= numB;
    numB ^= numA;
    numA ^= numB;

    if (numA < numC) {
      numA ^= numC;
      numC ^= numA;
      numA ^= numC;
    }
  }
  else {
    if (numB < numC) {
      numB ^= numC;
      numC ^= numB;
      numB ^= numC;
    }
  }
  
  jsConsole.writeLine(numA + " " + numB + " " + numC);
}
