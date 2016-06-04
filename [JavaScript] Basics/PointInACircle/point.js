function InCircle() {
  var x = Number(document.getElementById("x").value);
  var y = Number(document.getElementById("y").value);

  var distance = Math.sqrt((x * x) + (y * y));

  if (distance < 5) {
    jsConsole.writeLine("true");
  }
  else {
    jsConsole.writeLine("false");
  }
}