function solve(args) {
  var input = String(args);

  var length = input.length;
  var output = "";
  var isTeen = false;

  if (length == 3) {
    var digit = input.charAt(0);

    switch (digit) {
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

    input = input.substr(1, 2);
  }

  if (length >= 2) {

    var digit = input.substring(0, 1);

    if (digit === '1') {
      if (length === 3) {
        output += " and ";
      }
      isTeen = true;
      var digit = input.substring(0, 2);
      switch (digit) {
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
    }
    else {
      if (length == 3 && input[1] !== '0')  {
        output += " and ";
      }
      digit = input.substring(0, 1);

      switch (digit) {
        case "2":
          output += "twenty";
          break;
        case "3":
          output += "thirty";
          break;
        case "4":
          output += "forty";
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

      input = input.substr(1);
    }
  }

  if (!isTeen) {
    var digit = input.substr(0);
    switch (digit) {
      case "0":
        if (length == 1) {
          output += "zero";
        }
        break;
      case "1":
        output += " one";
        break;
      case "2":
        output += " two";
        break;
      case "3":
        output += " three";
        break;
      case "4":
        output += " four";
        break;
      case "5":
        output += " five";
        break;
      case "6":
        output += " six";
        break;
      case "7":
        output += " seven";
        break;
      case "8":
        output += " eight";
        break;
      case "9":
        output += " nine";
        break;
    }
  }

  var replacespaces = new RegExp('  ', 'g');

  output = output.trim();

  var firstChar = output[0];
  firstChar = firstChar.toUpperCase();
  var print = firstChar + output.slice(1);
  print = print.replace(replacespaces, ' ');
  console.log(print);
}
