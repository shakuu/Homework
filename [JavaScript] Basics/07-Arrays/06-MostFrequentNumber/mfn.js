var datain = document
  .getElementById('data-in');

var btngo = document
  .getElementById('go')
  .addEventListener('click', function () {
    var args = datain.value;
    MFN(args);
  });

function MFN(args) {
  var arr = SplitInput(args);
  var occurances = new Array(0);
  var uniqueElements = new Array(0);

  var index;
  var len = arr.length;

  for (index = 0; index < len; index += 1) {

    var indexOfElement = uniqueElements.indexOf(arr[index]);

    if (indexOfElement < 0) {
      uniqueElements.push(arr[index]);
      occurances.push(1);
    } else {
      occurances[indexOfElement] += 1;
    }
  }

  FindMax(occurances);
}

function FindMax(args) {
  var max = args[0];

  var index = 1;
  var length = args.length;
  for (index; index < length; index += 1) {

    if (args[index] > max) {
      max = args[index];
    }
  }

  console.log(max);
}

function SplitInput(args) {

  var input = String(args)
    .trim()
    .replace(/,/g, '')
    .split(' ');

  return input;
}