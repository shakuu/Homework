function solve(params) {
  var rows = +params[0],
    cols = +params[1],
    moves = params[2 + rows],
    board = [];

  function qMove(startR, startC, endR, endC) {
    var distRows = Math.abs(+startR - +endR);
    var distCols = Math.abs(+startC - +endC);

    // Check if it's a valid move
    if ((distRows !== distCols
      && !(distRows === 0 && distCols !== 0)
      && !(distCols === 0 && distRows !== 0))
      || (distRows === 0 && distCols === 0)) {
      return false;
    }

    // Diagonal
    if (distRows === distCols) {
      // Diagonal + +
      if ((startR > endR && startC > endC) || (startR < endR && startC < endC)) {
        var row = Math.min(startR, endR) + 1,
          col = Math.min(startC, endC) + 1;

        while (row <= Math.max(startR, endR)) {
          if (row === startR && col === startC) {
            row += 1;
            col += 1
            continue;
          }

          if (board[row][col] !== '-') {
            return false;
          }

          row += 1;
          col += 1;
        }
      }

      // Diagonal + -
      if ((startR > endR && startC < endC)
        || (startR < endR && startC > endC)) {
        var row = Math.min(startR, endR),
          col = Math.max(startC, endC);

        while (row <= Math.max(startR, endR)) {
          if (row === startR && col === startC) {
            row += 1;
            col -= 1;
            continue;
          }

          if (board[row][col] !== '-') {
            return false;
          }

          row += 1;
          col -= 1;
        }
      }
    } else { // Straight Line
      // move row
      if (distCols === 0) {
        for (var i = Math.min(startR, endR); i <= Math.max(startR, endR); i += 1) {
          if (i === Math.min(startR, endR)) {
            continue;
          }

          if (board[i][startC] !== '-') {
            return false;
          }
        }
      }

      if (distRows === 0) {
        for (var i = Math.min(startC, endC); i <= Math.max(startC, endC); i += 1) {
          if (i === Math.min(startC, endC)) {
            continue;
          }

          if (board[startR][i] !== '-') {
            return false;
          }
        }
      }
    }

    return true;
  }

  function kMove(startR, startC, endR, endC) {
    var distRows = Math.abs(+startR - +endR);
    var distCols = Math.abs(+startC - +endC);

    // valid move 
    if (!((distRows === 2 && distCols === 1) ||
      (distRows === 1 && distCols === 2))) {
      return false;
    }

    // Target
    if (board[+endR][+endC] !== '-') {
      return false;
    }

    return true;
  }

  // Fill the Board
  for (var i = rows; i >= 1; i -= 1) {
    board[i] = params[2 + rows - i] + '';
  }

  for (var i = 0; i < moves; i += 1) {
    var move = params[rows + 3 + i] + '',
      startRow = move.charCodeAt(1) - 48,
      startCol = move.charCodeAt(0) - 97,
      targetRow = move.charCodeAt(4) - 48,
      targetCol = move.charCodeAt(3) - 97;

    if (board[startRow][startCol] === 'K') {
      // Evaluate Knight move.
      if (kMove(startRow, startCol, targetRow, targetCol)) {
        console.log('yes');
      } else {
        console.log('no');
      }
    } else if (board[startRow][startCol] === 'Q') {
      // Evaluate Queen move.
      if (qMove(startRow, startCol, targetRow, targetCol)) {
        console.log('yes');
      } else {
        console.log('no');
      }
    } else {
      console.log('no');
    }
  }
}

var test1 = [
  '3',
  '4',
  '--K-',
  'K--K',
  'Q--Q',
  '12',
  'd1 b3',
  'a1 a3',
  'c3 b2',
  'a1 c1',
  'a1 b2',
  'a1 c3',
  'a2 c1',
  'd2 b1',
  'b1 b2',
  'c3 a3',
  'a2 a3',
  'd1 d3'
];

var test2 = [
  '5',
  '5',
  'Q---Q',
  '-----',
  '-K---',
  '--K--',
  'Q---Q',
  '10',
  'a1 a1',
  'a1 d4',
  'e1 b4',
  'a5 d2',
  'e5 b2',
  'b3 d4',
  'b3 c1',
  'b3 d1',
  'c2 a3',
  'c2 b4'
];

solve(test1);