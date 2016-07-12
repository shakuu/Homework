function LexMin() {
  DocMinMax(document);
  DocMinMax(window);
  DocMinMax(navigator);
}

function DocMinMax(objectToParse) {
  var docMin = objectToParse;
  var docMax = objectToParse;

  for (var key in objectToParse) {
    if (key < docMin) {
      docMin = key;
    }

    if (key > docMax) {
      docMax = key;
    }
  }

  console.log('Min :', docMin);
  console.log('Max :', docMax);
}
