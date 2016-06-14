var datain = document
  .getElementById('data-in');

var gobtn = document
  .getElementById('go')
  .addEventListener('click', function () {
    var arr = GetInput();
    arr = SelectionSort(arr);

    var find = prompt('Value to Search for');

    BinSearch(arr, find);
  });

function BinSearch(arr, find) {
  var left = 0;
  var right = arr.length - 1;
  var mid = 0;
  while (true) {
    mid = Math.floor(left + (Math.floor((right - left) / 2)));
    
    if (mid == left || mid == right ) {
      console.log('not found');
      break;
    }

    if (find == arr[mid]) {
      console.log('Success at position : ' + mid);
      break;
    }

    if (find < arr[mid]) {
      right = mid;
    } else if (find > arr[mid]) {
      left = mid;
    }
  }
}

function SelectionSort(args) {
  var input = args;

  var len = input.length;
  for (var i = 0; i < len; i += 1) {
    for (var j = i + 1; j < len; j += 1) {
      if (input[j] < input[i]) {
        input[j] ^= input[i];
        input[i] ^= input[j];
        input[j] ^= input[i];
      }
    }
  }
  return input;
}

function GetInput() {
  var input = String(datain.value)
    .trim()
    .replace(/,/g, '')
    .split(' ');

  return input;
}