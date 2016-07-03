function solve(args) {
    var i, j,
        variables = [],
        variablesList = [],
        scopeStack = [],
        scope = 'currentOperation',
        currentResult = 0;

    // Extract all Variables and their values.
    variables[scope] = {
        'operation': '',
        'values': []
    };
    scopeStack.push('noscope');

    for (i = 0; i < args.length; i += 1) {
        var line = args[i].replace(/\s\s+/g, ' '),
            curWord = '',
            curChar = '',
            isClojure = false,
            isNewDefinition = false,
            currentOperation = '',
            isValue = false;

        for (j = 0; j < line.length; j += 1) {
            curChar = line[j];

            if (curChar === '(') {
                scopeStack.push(scope);
                isClojure = true;
                isValue = false;
            } else if (curChar === ' ' || curChar === ')') {
                // Evaluate the current word.
                // console.log(curWord);

                if (curWord === '') {
                    // Do nothing.

                } else if (curWord === 'def') {
                    // Define a new variable.
                    isNewDefinition = true;

                } else if (curWord === '+' || curWord === '-' || curWord === '*' || curWord === '/') {
                    // Next sequence of words are values.
                    isValue = true;
                    variables[scope].operation = curWord;
                } else if (isNewDefinition) {
                    // Add a new variable.
                    variables[curWord] = {
                        'operation': '',
                        'values': []
                    };
                    isNewDefinition = false;
                    isValue = true;
                    scope = curWord;
                    variablesList.push(curWord);

                } else if (isValue) {
                    // Evalueate value.
                    variables[scope].values.push(curWord);
                }

                // If closing bracket get exit statement.
                if (curChar === ')') {
                    scope = scopeStack.pop();

                    if (scope === 'noscope') {
                        isClojure = false;
                        isValue = false;
                    }
                }

                curWord = '';

            } else if (isClojure) {
                curWord += curChar;
            }
        }
    }

    // Test Print
    // console.log(variables);

    function getPlus(args) {
        var len = args.values.length,
            i, j,
            sum = 0;

        for (i = 0; i < len; i += 1) {

            if (+args.values[i] || args.values[i] === '0') {

                sum += +args.values[i];

            } else {

                for (j = 0; j < variables[args.values[i]].values.length; j += 1) {
                    sum += +variables[args.values[i]].values[j];
                }

            }

        }

        return [sum];
    }

    function getMinus(args) {
        var len = args.values.length,
            i, j,
            sum = 0;

        for (i = 0; i < len; i += 1) {

            if (+args.values[i] || args.values[i] === '0') {

                sum -= +args.values[i];

            } else {

                for (j = 0; j < variables[args.values[i]].values.length; j += 1) {
                    sum -= +variables[args.values[i]].values[j];
                }

            }

        }

        return [sum];
    }

    function getMulti(args) {
        var len = args.values.length,
            i, j,
            sum = 1;

        for (i = 0; i < len; i += 1) {

            if (+args.values[i] || args.values[i] === '0') {

                sum *= +args.values[i];

            } else {

                for (j = 0; j < variables[args.values[i]].values.length; j += 1) {

                    sum *= +variables[args.values[i]].values[j];

                }

            }

        }

        return [sum];
    }

    function getDivide(args) {
        var len = args.values.length,
            i, j,
            sum = 0;

        if (+args.values[0] || args.values[i] === '0') {

            sum = +args.values[0];

        } else {

            sum = variables[args.values[0]].values[0];

            if (sum === 0) {
                return false;
            }

            for (j = 1; j < variables[args.values[0]].values.length; j += 1) {

                if (+variables[args.values[0]].values[j] === 0) {
                    return false;
                }

                sum = Math.floor(sum / variables[args.values[0]].values[j]);
            }

        }

        for (i = 1; i < len; i += 1) {

            if (+args.values[i] || args.values[i] === '0') {

                if (+args.values[i] === 0) {
                    return false;
                }

                sum = Math.floor(sum / +args.values[i]);

            } else {

                for (j = 0; j < variables[args.values[i]].values.length; j += 1) {
                    if (+variables[args.values[i]].values[j] === 0) {
                        return false;
                    }

                    sum = Math.floor(sum / variables[args.values[i]].values[j]);
                }

            }

        }

        return [sum];
    }

    // Evaluate the expressions 1 to length , 0 should be result.
    for (i = 0; i < variablesList.length; i += 1) {
        var current = variables[variablesList[i]];

        if (current.operation === '+') {
            current.values = getPlus(current);
        } else if (current.operation === '-') {
            current.values = getMinus(current);
        } else if (current.operation === '*') {
            current.values = getMulti(current);
        } else if (current.operation === '/') {
            current.values = getDivide(current);

            if (!current.values) {
                console.log('Division by zero! At Line:' + (i + 1));
                return;
            }
        }

        // console.log(current);
    }

    var current = variables['currentOperation'];

    if (current.operation === '+') {
        current.values = getPlus(current);
    } else if (current.operation === '-') {
        current.values = getMinus(current);
    } else if (current.operation === '*') {
        current.values = getMulti(current);
    } else if (current.operation === '/') {
        current.values = getDivide(current);

        if (!current.values) {
            console.log('Division by zero! At Line:' + args.length);
            return;
        }
    }

    console.log(current.values[0]);
}

module.exports = {
    solve
};