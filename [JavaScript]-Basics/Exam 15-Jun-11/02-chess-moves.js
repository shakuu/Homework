function solve(args) {
    const CONSTANTS = {
        "ROOK": 'R',
        "QUEEN": 'Q',
        "BISHOP": 'B',
        "EMPTY": '-',
        "YES": 'yes',
        "NO": 'no'
    };

    let rows = +args[0],
        cols = +args[1],
        numberOfTests = +args[rows + 2],
        tests = args.slice(2 + rows + 1)
            .map(convertCoordinatesInput),
        board = args.slice(2, 2 + rows)
            .map(String);

    // Convert coordinates from input format to array format - working
    function convertCoordinatesInput(str) {
        let input = (str + '')
            .toLowerCase()
            .split(' ');

        return {
            "fromRow": rows - +input[0][1],
            "fromCol": input[0][0].charCodeAt(0) - 'a'.charCodeAt(0),
            "toRow": rows - +input[1][1],
            "toCol": input[1][0].charCodeAt(0) - 'a'.charCodeAt(0),
        };
    }

    // DeltaX and DeltaY must be equal
    function checkIfValidDiagonalMove(move) {
        let deltaRow = Math.abs(move.fromRow - move.toRow),
            deltaCol = Math.abs(move.fromCol - move.toCol);

        return deltaRow === deltaCol;
    }

    // If FromRow equals ToRow or FromCol equals ToCol
    function checkIfValidLineMove(move) {
        return move.fromRow === move.toRow || move.fromCol === move.toCol;
    }

    function getDelta(move) {
        let deltaRow = move.toRow - move.fromRow,
            deltaCol = move.toCol - move.fromCol;

        return {
            "deltaRow": deltaRow > 0 ? 1 : deltaRow < 0 ? -1 : 0,
            "deltaCol": deltaCol > 0 ? 1 : deltaCol < 0 ? -1 : 0,
        };
    }

    function evaluateMove(move) {
        let delta = getDelta(move),
            position = {
                "row": move.fromRow,
                "col": move.fromCol
            };

        position.row += delta.deltaRow;
        position.col += delta.deltaCol;

        while (board[position.row] && board[position.row][position.col]) {
            if (board[position.row][position.col] !== CONSTANTS.EMPTY) { // return false if cell is not empty
                return false;
            } else if (position.row === move.toRow && position.col === move.toCol) { // Return true if successfully reached target
                return true;
            }

            position.row += delta.deltaRow;
            position.col += delta.deltaCol;
        }

        return false; // return false if out of bounds of the array
    }

    for (let test in tests) {
        let cellContents = board[tests[test].fromRow][tests[test].fromCol];

        if (cellContents === CONSTANTS.QUEEN) {
            // Evaluate queen move
            if (checkIfValidDiagonalMove(tests[test]) || checkIfValidLineMove(tests[test])) {

                if (evaluateMove(tests[test])) {
                    console.log(CONSTANTS.YES);
                } else {
                    console.log(CONSTANTS.NO);
                }
                
            } else {
                console.log(CONSTANTS.NO);
            }
        } else if (cellContents === CONSTANTS.ROOK) {
            // Evaluate rook move
            // Check if a valid straight line
            if (checkIfValidLineMove(tests[test])) {

                if (evaluateMove(tests[test])) {
                    console.log(CONSTANTS.YES);
                } else {
                    console.log(CONSTANTS.NO);
                }

            } else {
                console.log(CONSTANTS.NO);
            }
        } else if (cellContents === CONSTANTS.BISHOP) {
            // Evaluate bishop move
            // Check if a valid Diagonal
            if (checkIfValidDiagonalMove(tests[test])) {

                if (evaluateMove(tests[test])) {
                    console.log(CONSTANTS.YES);
                } else {
                    console.log(CONSTANTS.NO);
                }

            } else {
                console.log(CONSTANTS.NO);
            }
        } else if (cellContents === CONSTANTS.EMPTY) {
            console.log(CONSTANTS.NO);
        }
    }
    // Test print
    console.log(tests);
    console.log(board);
}

module.exports = {
    solve
};