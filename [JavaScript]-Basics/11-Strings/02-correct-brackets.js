function solve(str) {
  var input = str[0] + '',
    openBracket = 0,
    closeBracket = 0,
    brackets = [],
    counter = 0;

  for (var i in input) {
    var c = input[i];

    if (c === '(') {
      openBracket += 1;
    } else if (c === ')') {
      closeBracket += 1;
    }

    if (closeBracket > openBracket) {
      console.log('Incorrect');
      return;
    }
  }

  // Output
  if (openBracket === closeBracket) {
    console.log('Correct');
  } else {
    console.log('Incorrect');
  }
}

solve([ '((a+b)/5-d)' ]);