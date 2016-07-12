function solve(args) {

  var input = Number(+args[0]);

  if (input % 2 == 0) {
    output = "even";
  }
  else {
    output = "odd";
  }

  console.log(output + ' ' + input);
}
