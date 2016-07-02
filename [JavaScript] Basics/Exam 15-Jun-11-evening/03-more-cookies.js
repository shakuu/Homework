function solve(args) {
    var lines = args.slice().map(String),
        scopeCounter = 0,
        counter = 0,
        scopes = [],
        bodies = [],
        curScope = 1,
        prevScope = [];

    function removeEmptySpaces(str) {
        var line = str + '',
            output = '',
            prevChr = '',
            isColon = false;

        for (var i in line) {
            if (line[i] === ':') {
                output += line[i] + ' ';
            } else if (line[i] === ' '
                || line[i] === '\t') {
                continue;
            } else {
                output += line[i];
            }
        }

        return output;
    }

    function getScope(params) {
        var counter = +params + 1;

        var scope = scopes
            .slice(1, counter)
            .join(' ');

        return scope;
    }

    function print() {
        for (var i in scopes) {
            console.log(scopes[i] + ' {');
            console.log(bodies[i].join('\n'));
            console.log('}');
        }
    }

    for (var row in lines) {
        var curLine = (lines[row] + '').trim();
        curLine = removeEmptySpaces(curLine);

        if (curLine.charAt(curLine.length - 1) === '{') {
            // new scope
            if (scopes[curScope] === undefined) {
                scopes[curScope] = '';
            }

            var addScope = scopes[curScope] + '';

            curLine = curLine.slice(0, curLine.length - 1).trim();

            if (curLine.charAt(0) === '$') {
                curLine = curLine.slice(1);
                addScope = addScope + curLine;
            } else {
                addScope = addScope + ' ' + curLine;
            }

            counter += 1;
            scopeCounter += 1;
            scopes[counter] = addScope.trim();

            prevScope.push(curScope);
            curScope = counter;
        } else if (curLine.charAt(curLine.length - 1) === ';') {
            // new property
            if (bodies[curScope] === undefined) {
                bodies[curScope] = [];
            }

            bodies[curScope].push('  ' + curLine);
        } else if (curLine.charAt(curLine.length - 1) === '}') {
            // end of scope.
            scopeCounter -= 1;
            curScope = prevScope.pop();

            if (scopeCounter === 0) {
                // Print accumulated info
                print();

                // Clear all info
                scopes = [];
                bodies = [];
                counter = 0;
            }
        }
    }
}

var test1 = [
    '#the-big-b{',
    'color: big-yellow;',
    '.little-bs {',
    'color: little-yellow;',
    '$.male            {',
    'color: middle-yellow;',
    '}',
    '}',
    '}',
    '.muppet           {',
    'skin        :        fluffy;',
    '$.water-spirit    {',
    'powers    :     water;',
    '}',
    '$>thread{',
    'color: depends;',
    '}',
    'powers    :      all-muppet-powers;',
    '}'
];

solve(test1);