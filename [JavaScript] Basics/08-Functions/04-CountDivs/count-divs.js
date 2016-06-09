var gobtn = document
  .getElementById('go')
  .addEventListener('click', function () {
    CountElements();
  })

function CountElements() {
  var test = document.body.getElementsByTagName('div');
  console.log(test.length);
}