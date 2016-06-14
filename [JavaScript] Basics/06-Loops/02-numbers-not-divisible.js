function NotDivable() {
  var input = parseInt(document.getElementById('a').value);

  for (var index = 0; index <= input; index += 1) {
    var element = index;

    if (element % 3 !== 0 && element % 7 !== 0) {
      console.log(element);
    }
  }
}