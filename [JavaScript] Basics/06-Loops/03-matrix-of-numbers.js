function solve(args) {
  
  var rows = +args;
  var strMatrix = [];

  for (let row = 0; row < rows; row += 1) {

    strMatrix[row] = '';
    var fill = row + 1;

    for (let col = 0; col < rows; col += 1) {
      strMatrix[row] += String(fill) + ' ';
      fill += 1;
    }

    strMatrix[row] = String(strMatrix[row]).trim();
    console.log(strMatrix[row]);
  }
}

solve('4');