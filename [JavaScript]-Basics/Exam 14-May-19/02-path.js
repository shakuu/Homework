function solve(args) {
    var size = args[0].split(' ').map(Number),
        matrix = args.slice(1).map(function (a) {
            return a.split(' ');
        }),
        // flags = Array(size[0])
        //     .fill([], 0, size[0]).map(function (a) {
        //         a = Array(size[1]).fill(false);
        //         return a;
        //     }),
        flags = [],
        row = 0,
        col = 0,
        sum = 0,
        i, j;

    for (i = 0; i < size[0]; i += 1) {
        flags[i] = [];
        for (j = 0; j < size[1]; j += 1) {
            flags[i][j] = false;
        }
    }

    function getValue(row, col) {
        return Math.pow(2, +row) + (+col);
    }

    while (true) {
        sum += getValue(row, col);
        flags[row][col] = true;

        // Change positions.
        if (matrix[row][col] === 'dr') {
            row += 1;
            col += 1;
        } else if (matrix[row][col] === 'dl') {
            row += 1;
            col -= 1;
        } else if (matrix[row][col] === 'ur') {
            row -= 1;
            col += 1;
        } else if (matrix[row][col] === 'ul') {
            row -= 1;
            col -= 1;
        }

        // Check out of range
        if (row < 0 || size[0] <= row
            || col < 0 || size[1] <= col) {
            console.log('successed with ' + sum);
            break;
        }

        // Check Visite
        if (flags[row][col]) {
            console.log('failed at (' + row + ', ' + col + ')');
            break;
        }
    }
}


var test1 = [
    '3 5',
    'dr ur dr ul dr',
    'dr ur dr dl dr',
    'dr ur dr ul dr'
];

var test2 = args = [
    '3 5',
    'dr dl dr ur ul',
    'dr dr ul ur ur',
    'dl dr ur dl ur'
];
var test3 = args = [
    '3 5',
    'dr dl dl ur ul',
    'dr dr ul ul ur',
    'dl dr ur dl ur'
];

solve(test3);
