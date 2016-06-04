function Area() {
  var x = document.getElementById("x").value;
  var y = document.getElementById("y").value;
  var h = document.getElementById("h").value;

  var output = Number(x) + Number(y);
  output /= 2;
  output *= h;

  jsConsole.writeLine(output);
}