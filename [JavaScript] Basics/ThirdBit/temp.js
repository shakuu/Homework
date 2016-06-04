function ThirdBit() {
  var input = document.getElementById("number").value;

  input = Number(input);
  var mask = 1 << 2;

  if ( (input & mask) == 0) {
    jsConsole.writeLine("0");
  }
  else {
    jsConsole.writeLine("1");
  }
}