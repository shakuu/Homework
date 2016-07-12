
function PrintOutput(out) {
  if (out >= 0) {
    console.log('Found at: ' + out);
  } else {
    console.log('not found');
  }
}

function FindFirst(arr) {
  var index = 1;
  var len = arr.length - 1;

  for (index; index < len; index += 1) {
    if (LargerThan(arr, index)) {
      return index;
    }
  }

  return -1;
}

function GetRandomNumber(min, max) {
  var numb = (min + Math.random() * (max - min + 1)) | 0;
  // numb = Math.floor(numb);
  return numb;
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