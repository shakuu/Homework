var datain = document
  .getElementById('data-in');

var btngo = document
  .getElementById('go')
  .addEventListener('click', function () {
    var input = datain.value;
    var arr = GetArray(input);
    // var len = arr.length - 1;
    // var toTest = GetRandomNumber(1, len);
    // var out = LargerThan(arr, toTest);
    var result = FindFirst(arr);
    PrintOutput(result);
  });


function GetArray(args) {

  var arr = String(args)
    .replace(/,/g, '')
    .split(' ')
    .map(Number);

  return arr;
}