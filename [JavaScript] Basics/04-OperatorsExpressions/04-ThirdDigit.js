function solve(params) {
  var input = Number(+params);

  var third = Math.floor(input / 100);
  third = third % 10;

  if (third === 7) {
    console.log('true');
  } else {
    console.log('false ' + third);
  }
}