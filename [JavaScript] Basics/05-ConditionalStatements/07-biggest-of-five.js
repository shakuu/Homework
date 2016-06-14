function Biggest(){
  var numA = Number(document.getElementById("a").value);
  var numB = Number(document.getElementById("b").value);
  var numC = Number(document.getElementById("c").value);
  var numD = Number(document.getElementById("d").value);
  var numE = Number(document.getElementById("e").value);
  
  var max  = numA;
  
  if (numB > max) {
    max = numB;
  }
  
  if (numC > max) {
    max = numC
  }
  
  if (numD > max) {
    max = numD;
  }
  
  if (numE > max) {
    max = numE;
  }
  
  jsConsole.writeLine(max);
}