function solve(args) {
    var size = (args[0] + '').split(' ').map(Number),
        matrix = args.slice(1).map(String),
        row = size[0] - 1,
        col = size[1] - 1,
        flags = [],
        score = 0,
        counter = 0,
        i, j;

    for (i = 0; i < size[0]; i += 1) {
        flags[i] = [];
        matrix[i] += '';
        for (j = 0; j < size[1]; j += 1) {
            flags[i][j] = false;
        }
    }

    function getNumber(crow, ccol) {
        return Math.pow(2, +crow) - (+ccol);
    }

    while (true) {
        score += getNumber(row, col);
        flags[row][col] = true;
        counter += 1;

        if (matrix[row][col] === '1') {
            row -= 2;
            col += 1;
        } else if (matrix[row][col] === '2') {
            row -= 1;
            col += 2;
        } else if (matrix[row][col] === '3') {
            row += 1;
            col += 2;
        } else if (matrix[row][col] === '4') {
            row += 2;
            col += 1;
        } else if (matrix[row][col] === '5') {
            row += 2;
            col -= 1;
        } else if (matrix[row][col] === '6') {
            row += 1;
            col -= 2;
        } else if (matrix[row][col] === '7') {
            row -= 1;
            col -= 2;
        } else if (matrix[row][col] === '8') {
            row -= 2;
            col -= 1;
        }

        if (flags[row][col]) {
            console.log('Sadly the horse is doomed in ' + counter + ' jumps');
            break;
        }

        if (row < 0 || size[0] <= row
            || col < 0 || size[1] <= col) {
            console.log('Go go Horsy! Collected ' + score + ' weeds');
            break;
        }
    }
}

var test1 = [
    '3 5',
    '54561',
    '43328',
    '52388',
];

var test2 = [
    '3 5',
    '54361',
    '43326',
    '52188',
];

solve(test2);