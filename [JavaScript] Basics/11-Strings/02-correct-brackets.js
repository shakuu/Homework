// jshint  esversion: 6

// Simple no correct check.
function CountBrackets(str) {
  let input = String(str);
  let openBracket = 0;
  let closeBracket = 0;

  // Count open brackets.
  let index = input.indexOf('(');
  while (index >= 0) {
    openBracket += 1;
    index = input.indexOf('(', index + 1);
  }

  // Count close brackets.
  index = input.indexOf(')');
  while (index >= 0) {
    closeBracket += 1;
    index = input.indexOf(')', indes + 1);
  }

  // Output
  if (openBracket === closeBracket) {
    return true;
  } else {
    return false;
  }
}