function solve(params) {
  var empty = '-';
  var rooks = 'R';
  var queens = 'Q';
  var bishops = 'B';

  var rows = parseInt(params[0]),
    cols = parseInt(params[1]),
    tests = parseInt(params[rows + 2]), i, move;

  for (i = 0; i < tests; i++) {
    move = params[rows + 3 + i];
    // Your solution here
    var isLine = false;
    var isDiag = false;

    // Split move string 
    var instrtuctons = String(move).split(' ');
    var startCol = +instrtuctons[0].charCodeAt(0) - 97;
    var startRow = rows - +instrtuctons[0].charAt(1);

    var endCol = +instrtuctons[1].charCodeAt(0) - 97;
    var endRow = rows - +instrtuctons[1].charAt(1);

    // Check Path
    if (startCol === endCol) isLine = true;
    if (startRow === ennRow) isLine = true;

    var dCol = Math.abs(startCol - endCol);
    var dRow = Math.abs(startRow - endRow);

    if (dCol === dRow) isDiag = true;

    // token type
    var token = 

    console.log('yes'); // or console.log('no');
  }
}

var input = [
  '3',
  '4',
  '--R-',
  'B--B',
  'Q--Q',
  '12',
  'd1 b3',
  'a1 a3',
  'c3 b2',
  'a1 c1',
];

solve(input);