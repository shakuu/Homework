var datain = document
  .getElementById('data-in');

var gobtn = document
  .getElementById('go')
  .addEventListener('click', function () {
    args = datain.value;
    SelectionSort(args);
  })

function SelectionSort(args) {

  var input = String(args)
    .replace(/,/g, '')
    .split(' ');

  var len = input.length;
  for (var i = 0; i < len; i += 1) {
    for (var j = i + 1; j < len; j += 1) {
      if (input[j]<input[i]) {
        input[j] ^= input[i];
        input[i] ^= input[j];
        input[j] ^= input[i];
      }
    }
  }

  console.log(input);
}