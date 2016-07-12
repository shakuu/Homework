var btngo = document
  .getElementById('go')
  .addEventListener('click', function () {
    var size = GetRandomNumber(50, 500);
    var array = CreateArray(size);
    var find = GetRandomNumber(0, 100);
    var result = SearchArray(array, find);

    console.log('Appearance Count: ' + result);
  })

function GetRandomNumber(min, max) {
  var random = Math.random() * (max - min) + min;
  random = Math.floor(random);
  return random;
}

function CreateArray(size) {
  var array = new Array(size);

  var index = 0;
  var numb = 0;

  for (index; index < size; index += 1) {
    numb = GetRandomNumber(0, 100);
    array[index] = numb;
  }

  return array;
}

function SearchArray(search, find) {
  find = find || GetRandomNumber(1, 100);

  var length = search.length;
  var index = 0;
  var counter = 0;

  for (index; index < length; index += 1) {
    if (search[index] == find) {
      counter += 1;
    }
  }

  return counter;
}