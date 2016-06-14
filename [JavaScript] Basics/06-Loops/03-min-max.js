function MinMax() {
  var input = String(document.getElementById('a').value);
  var arr = input.split(' ');
  var arrNum = Array(arr.length);

  for (var index = 0; index < arr.length; index++) {
    var element = arr[index];

    arrNum[index] = parseInt(element, 10);
  }

  GetMax(arrNum);
  GetMin(arrNum);
}

function GetMax(arr) {
  var max = arr[0];

  for (var index = 1; index < arr.length; index++) {
    var element = arr[index];
    if (element > max) {
      max = element;
    }
  }
  console.log("Max Element = " + max);
}

function GetMin(arr) {
  var min = arr[0];

  for (var index = 1; index < arr.length; index++) {
    var element = arr[index];

    if (element < min) {
      min = element;
    }
  }

  console.log('Min Element = ' + min);
}