function Biggest() {
  var numA = Number(document.getElementById("a").value);
  var numB = Number(document.getElementById("b").value);
  var numC = Number(document.getElementById("c").value);

  if (numA >= numB) {
    if (numA >= numC) {
      jsConsole.writeLine(numA);
    }
    else {
      jsConsole.writeLine(numC);
    }
  }
  else {
    if (numB >= numC) {
      jsConsole.writeLine(numB);
    }
    else {
      jsConsole.writeLine(numC);
    }
  }
}