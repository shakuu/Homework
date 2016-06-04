function OddOrEven() {
  var input = document.getElementById("input");
  if (input.value % 2 == 0) {
    var ouput = "even";
  }
  else {
    var output = "odd";
  }
  
  jsconsole.writeLine(output);
}