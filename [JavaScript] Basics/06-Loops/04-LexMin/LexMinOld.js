function LexMin() {
  var input = document
    .getElementById('a').value;

  var words = String(input).split(' ');

  var min = words[0];

  for (var index = 0; index < words.length; index += 1) {
    var element = words[index];

    if (element < min) {
      min = element;
    }
  }

  console.log(min);
}