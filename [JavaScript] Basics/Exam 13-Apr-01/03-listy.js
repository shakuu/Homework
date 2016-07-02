function solve(args) {
    var lineNr = 0,
        isVariable = false,
        variables = [],
        result = 0;

    var matchCommand = /(?:(def) (\w[\w|\d]*) )?(\w\w\w)?(\[.*?\])/g,
        matchValues = /\[.*?\]/;

    var CONSTANTS = {
        "DEF": 'def',
        "MIN": 'min',
        "MAX": 'max',
        "SUM": 'sum',
        "AVG": 'avg',
        "NOOPERATION": false,
        "SEPARATOR": '['
    };

    function getSum(args) {
        var numbers = args.slice().map(Number),
            output = 0, i;

        for (i = 0; i < numbers.length; i += 1) {
            output += numbers[i];
        }

        return [output];
    }

    function getAvg(args) {
        var sum = getSum(args);

        return [Math.floor( sum / args.length)];
    }

    function getMin(args) {
        var numbers = args.slice().map(Number),
            min = 0, i;

        min = numbers[0];
        for (i = 1; i < numbers.length; i += 1) {
            min = numbers[i] < min ? numbers[i] : min;
        }

        return [min];
    }

    function getMax(args) {
        var numbers = args.slice().map(Number),
            max = 0, i;

        max = numbers[0];
        for (i = 1; i < numbers.length; i += 1) {
            max = numbers[i] > max ? numbers[i] : max;
        }

        return [max];
    }

    function extractValues(val) {
        var output = [], i, j,
            values = (val + '')
                .replace(/\[/, '')
                .replace(/\]/, '')
                .split(',');

        for (i = 0; i < values.length; i += 1) {
            if (+values[i]) {
                output.push(+values[i]);
            } else {
                for (j = 0; j < variables[values[i]].length; j += 1) {
                    output.push(variables[values[i]][j]);
                }

                // output.push(...variables[values[i]]);
            }
        }

        return output;
    }

    for (lineNr = 0; lineNr < args.length; lineNr += 1) {
        var line = (args[lineNr] + '')
            .replace(/\s\s+/g, ' '),
            currentVariable = 'currentOperation',
            currentValues = [],
            currentOperation = CONSTANTS.NOOPERATION,
            i;

        // Extract all informatation
        var match = matchCommand.exec(line)
            .filter(function (m) {
                return m !== undefined;
            })
            .map(function (m) {
                return (m + '').trim().replace(/\s+/g, '');
            })
            .slice(1);
        // Empty exec to avoid null.
        matchCommand.exec(line);

        // Parse line 
        for (i = 0; i < match.length; i += 1) {
            var current = match[i];

            if (current === CONSTANTS.DEF) {
                // Initialize the variable
                variables[match[i + 1]] = [];
                currentVariable = match[i + 1];
            } else if (current === CONSTANTS.SUM ||
                current === CONSTANTS.AVG ||
                current === CONSTANTS.MIN ||
                current === CONSTANTS.MAX) {

                currentOperation = current;
            } else if (matchValues.test(current)) {
                variables[currentVariable] = extractValues(current);
            }
        }

        // Perform the operation
        if (currentOperation) {
            if (currentOperation === CONSTANTS.SUM) {
                variables[currentVariable] = getSum(variables[currentVariable]);
            } else if (currentOperation === CONSTANTS.AVG) {
                variables[currentVariable] = getAvg(variables[currentVariable]);
            } else if (currentOperation === CONSTANTS.MIN) {
                variables[currentVariable] = getMin(variables[currentVariable]);
            } else if (currentOperation === CONSTANTS.MAX) {
                variables[currentVariable] = getMax(variables[currentVariable]);
            }
        }

        if (lineNr === args.length - 1) {
            console.log(variables[currentVariable].join(''));
        }
    }
}

module.exports = {
    solve
};