function Sign() {
  var numA = Number(document.getElementById("a").value);
  var numB = Number(document.getElementById("b").value);
  var numC = Number(document.getElementById("c").value);

  var isZero = false;
  var negativeCounter = 0;

  if (numA == 0 || numB == 0 || numC == 0) {
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
    jsConsole.writeLine("0");
  }
  else {
    if (negativeCounter % 2 ==  0) {
      jsConsole.writeLine("+");
    }
    else{
      jsConsole.writeLine("-");
    }
  }
}