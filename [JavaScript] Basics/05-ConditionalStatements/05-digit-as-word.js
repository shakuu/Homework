function DAW() {
  var digit = document.getElementById("a").value;
  var output = '';

  switch (digit) {
    case "0":
      output = "zero";
      break;
    case "1":
      output = "one";
      break;
    case "2":
      output = "two";
      break;
    case "3":
      output = "three";
      break;
    case "4":
      output = "four";
      break;
    case "5":
      output = "five";
      break;
    case "6":
      output = "six";
      break;
    case "7":
      output = "seven";
      break;
    case "8":
      output = "eight";
      break;
    case "9":
      output = "nine";
      break;
    default:
      output = "not a digit";
      break;
  }
  
  jsConsole.writeLine(output);
}