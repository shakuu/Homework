function IsPrime() {
  var number = Number (document.getElementById("number").value);
  
  number = number.toFixed();
  var isPrime = true;
  
  for (var divisor = 0; divisor < Math.sqrt(number).toFixed(); divisor++) {
    var element = Math.sqrt(number).toFixed();
    
    if (number % element == 0) {
      isPrime = false;
      break;
    }
  }
  
  jsConsole.writeLine(isPrime);
}