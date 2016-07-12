function solve(args) {
    var size = args[0].split(' ').map(Number),
        position = args[1].split(' ').map(Number),
        labyrinth = args.slice(2).map(function (x) {
            return x.split('');
        }),
        row, col,
        nextMove,
        nextDirection,
        sum = 0,
        moves = 0;

    var CONSTANTS = {
        "u": [-1, +0],
        "d": [+1, +0],
        "l": [+0, -1],
        "r": [+0, +1]
    };

    function getValue(row, col) {
        return (+row * (size[1])) + (+col + 1);
    }

    while (true) {
        
        sum += getValue(position[0], position[1]);

        nextDirection = labyrinth[position[0]][position[1]] + '';
        nextMove = CONSTANTS[nextDirection];

        labyrinth[position[0]].splice(position[1], 1, '0');

        position[0] += nextMove[0];
        position[1] += nextMove[1];
        moves += 1;

        if (!labyrinth[position[0]] || !labyrinth[position[0]][position[1]]) {
            console.log('out ' + sum);
            return;
        }

        if (labyrinth[position[0]][position[1]] === '0') {
            console.log('lost ' + moves);
            return;
        }
    }
}

module.exports = {
    solve
};