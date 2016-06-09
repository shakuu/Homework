var datain = document
  .getElementById('data-in');

var gobtn = document
  .getElementById('go')
  .addEventListener('click', function () {
    var input = datain.value;
    Reverse(input);
  });

function Reverse(args) {
  var output = '';
  var index = args.length - 1;
  
  for (index; index >= 0; index -= 1) {
    output = output.concat(args[index]);
  }

  console.log(output);
}