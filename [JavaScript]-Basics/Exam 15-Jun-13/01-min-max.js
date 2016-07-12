function solve(args) {
    "use strict";

    var length = +args[0],
        sequence = +args[1],
        numbers = args[2].split(' ').map(Number);

    var output = [],
        min = 0,
        max = 0;

    for (var i = 0; i <= numbers.length - sequence; i += 1) {

        min = numbers[i];
        max = numbers[i];

        for (var j = +i; j < +i + sequence; j += 1) {
            min = numbers[j] < min ? numbers[j] : min;
            max = numbers[j] > max ? numbers[j] : max;
        }

        output.push(+min + +max);
    }

    console.log(output.join(','));
}

module.exports = {
    solve
};