function Exchange() {
  var numberA = Number(document.getElementById("x").value);
  var numberB = Number(document.getElementById("y").value);
  
  if (numberA > numberB) {
    numberA ^= numberB;
    numberB ^= numberA;
    numberA ^= numberB;
  }
  
  jsConsole.writeLine(numberA + " " + numberB);
  console.log(numberA + " " + numberB);
}