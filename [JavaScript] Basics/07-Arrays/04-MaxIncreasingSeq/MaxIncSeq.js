var el = document
  .getElementById('go')
  .addEventListener('click', function () {
    var args = document
      .getElementById('data-in')
      .value;

    MaxIncSeq(args);
  });

function MaxIncSeq(arg) {

  var str = String(arg);
  str = str.replace(/,/g, '');
  var array = String(str).split(' ');

  var max = 0;
  var counter = 1;
  var prev = array[0];

  var len = array.length;
  for (var index = 1; index < len; index += 1) {
    var element = array[index];
    console.log(element);

    if (Number(element.trim(' ')) > Number(prev.trim(' '))) {
      counter += 1;
    } else {
      if (counter > max) {
        max = counter;
      }

      counter = 1;
      prev = element;
    }
  }

  if (counter > 1) {
    if (counter > max) {
      max = counter;
    }
  }

  console.log(max);
}