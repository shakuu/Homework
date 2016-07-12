function solve(args) {
    var size = args[0].split(' ').map(Number),
        position = args[1].split(' ').map(Number),
        jumpsCount = size.splice(2, 1),
        jumps = args.slice(2).map(function (j) {
            return j.split(' ').map(Number);
        }),
        field = [],
        row, col,
        sum = 0, moves = 0,
        jumpIndex = 0,
        nextJump = [];

    // Create the field.
    for (row = 0; row < size[0]; row += 1) {
        field[row] = [];

        for (col = 0; col < size[1]; col += 1) {
            field[row][col] = row * size[1] + col + 1;

        }
    }

    // Jump around.
    while (true) {

        // Collect the current cell
        sum += field[position[0]][position[1]];
        field[position[0]][position[1]] = 0;

        // Get the next jump.
        nextJump = jumps[jumpIndex];
        jumpIndex = (jumpIndex + 1) % jumpsCount;

        // Adjut the position.
        position[0] += nextJump[0];
        position[1] += nextJump[1];
        moves += 1;

        if (!field[position[0]] || !field[position[0]][position[1]]) {
            console.log('escaped ' + sum);
            return;
        }

        if (field[position[0]][position[1]] === 0) {
            console.log('caught ' + moves);
            return;
        }
    }
}

module.exports = {
    solve
};