function NumberAsWords() {
  var input = String(document.getElementById("a").value);

  var output = "";

  switch (input.charAt(0)) {
    case "1":
      output += "one hundred";
      break;
    case "2":
      output += "two hundred";
      break;
    case "3":
      output += "three hundred";
      break;
    case "4":
      output += "four hundred";
      break;
    case "5":
      output += "five hundred";
      break;
    case "6":
      output += "six hundred";
      break;
    case "7":
      output += "seven hundred";
      break;
    case "8":
      output += "eight hundred";
      break;
    case "9":
      output += "nine hundred";
      break;
  }

  output += " ";
  var isTwoDigits = false;

  switch (input.charAt(1)) {
    case "1":
      isTwoDigits = true;
      var twodigits = input.substr(1, 2);
      switch (twodigits) {
        case "10":
          output += "ten";
          break;
        case "11":
          output += "eleven";
          break;
        case "12":
          output += "twelve";
          break;
        case "13":
          output += "thirteen";
          break;
        case "14":
          output += "fourteen";
          break;
        case "15":
          output += "fifteen";
          break;
        case "16":
          output += "sixteen";
          break;
        case "17":
          output += "seventeen";
          break;
        case "18":
          output += "eigthteen";
          break;
        case "19":
          output += "nineteen";
          break;
      }
      break;
    case "2":
      output += "twenty";
      break;
    case "3":
      output += "thirty";
      break;
    case "4":
      output += "fourty";
      break;
    case "5":
      output += "fifty";
      break;
    case "6":
      output += "sixty";
      break;
    case "7":
      output += "seventy";
      break;
    case "8":
      output += "eighty";
      break;
    case "9":
      output += "ninety";
      break;
  }
  
  if (!isTwoDigits){
    output+= " ";
    
    switch (input.charAt(2)) {
        case "0":
          break;
        case "1":
          output += "one";
          break;
        case "2":
          output += "two";
          break;
        case "3":
          output += "three";
          break;
        case "4":
          output += "four";
          break;
        case "5":
          output += "five";
          break;
        case "6":
          output += "six";
          break;
        case "7":
          output += "seven";
          break;
        case "8":
          output += "eight";
          break;
        case "9":
          output += "nine";
          break;
      }
    
    jsConsole.writeLine(output);
  }
}