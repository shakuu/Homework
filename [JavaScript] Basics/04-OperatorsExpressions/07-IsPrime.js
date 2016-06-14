function solve(args) {
  var input = Number(args);
  var isPrime = true;

  if (input < 2) {
    console.log('false');
    return;
  }

  var len = Math.floor(Math.sqrt(input));
  for (var divisor = 2; divisor < len; divisor+=1) {

    if (input % divisor === 0) {
      isPrime = false;
      break;
    }
  }

 console.log(isPrime);
}

solve('2');