var datain = document
  .getElementById('data-in');

var btngo = document
  .getElementById('go')
  .addEventListener('click', function () {
    var input = datain.value;
    var arr = GetArray(input);
    var len = arr.length - 1;
    var toTest = GetRandomNumber(1, len);
    var out = LargerThan(arr, toTest);

    PrintOutput(out);
  });

function PrintOutput(out) {
  console.log(out);
}

function GetRandomNumber(min, max) {
  var numb = Math.random() * (max - min + 1) + min;
  numb = Math.floor(numb);
  return numb;
}

function GetArray(args) {

  var arr = String(args)
    .replace(/,/g, '')
    .split(' ');

  return arr;
}

function LargerThan(arr, index) {
  var len = arr.length;

  if (index === 0 || len == len - 1) {
    console.log('not eligible');
    return;
  }

  if (arr[index] > arr[index - 1] && arr[index] > arr[index + 1]) {
    return true;
  } else {
    return false;
  }
}