var datain = document
  .getElementById('data-in');

var gobtn = document
  .getElementById('go')
  .addEventListener('click', function () {
    var input = String(datain.value);
    FindWord(input);
  });

function FindWord(input, overload){
  var word = prompt('Word to find ?');
  var parse = input;

  switch (overload) {
    case 1:
      word = word.toLowerCase();
      parse = parse.toLowerCase();
      break;
    default:
      break;
  }  

  var words = parse.split(' ');
  var length = words.length;
  var index = 0;
  var counter= 0;

  for(index; index < length; index += 1){
    if (words[index] == word) {
      counter++;
    }
  }

  console.log(counter);
}
