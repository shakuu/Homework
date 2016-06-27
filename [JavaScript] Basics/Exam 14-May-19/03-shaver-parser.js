function solve(args) {
    var input = args,
        models = [],
        foreachModels = [],
        separators = [' ', '<'],
        key = '',
        isKey = false,
        i, line,
        output = [],
        spaces = 4,
        ifStatementResult = true,
        isForeach = false;

    // Construct indentation.
    // Return a string with the correct number of spaces.
    function getIndentation() {
        var line = output[output.length - 1],
            counter = 0,
            index = 0,
            outputStr = '';

        while (line[counter] === ' ' || line[counter] === '\t') {
            if (line[counter] === '\t') {
                counter += 4;
            } else {
                counter += 1;
            }
        }

        for (index = 0; index < counter + spaces; index += 1) {
            outputStr += ' ';
        }

        return outputStr;
    }

    // Parses model variables at the top of the file.
    // Adds to Models[].
    function parseModel(str) {
        var line = str + '',
            index = 0,
            title = '',
            value = '',
            len;

        // get title
        while (line[index] !== ':') {
            title += line[index];
            index += 1;
        }

        models[title] = [];

        len = line.length;
        for (var i = index + 1; i < len; i += 1) {
            if (line[i] === ',') {
                models[title].push(value);
                value = '';
                continue;
            }

            value += line[i];
        }

        models[title].push(value);
    }

    // Parses a @section tag, adds its content to the Models[].
    function parseSection(n) {
        var index = +n,
            isKey = false,
            isTitle = false,
            title = '';

        // Get Title, same row
        for (var i in args[index]) {
            var c = args[index][i];

            if (c === '@') {
                isKey = true;
            } else if (c === ' ' && isKey) {
                isTitle = true;
                isKey = false;
            } else if (c === ' ' && isTitle) {
                break;
            } else if (isTitle) {
                title += c;
            }
        }

        models[title] = [];
        index += 1;

        while (args[index].trim() !== '}') {
            models[title].push(args[index]);
            index += 1;
        }

        return index;
    }

    // Display the contents of the section.
    function parseRenderSection(n) {
        var index = +n,
            isTitle = false,
            title = '',
            line = '',
            indent = '',
            i;

        // Read Title.
        line = args[index].trim();
        for (i in line) {
            var c = line[i];

            if (c === '"' && !isTitle) {
                isTitle = true;
            } else if (c === '"' && isTitle) {
                break;
            } else if (isTitle) {
                title += c;
            }
        }

        // Add content to output.
        indent = getIndentation();
        for (i in models[title]) {
            output.push(indent + models[title][i]);
        }
    }

    // Evaluate IF statement
    function parseIf(n) {
        var line = args[+n] + '',
            isTitle = false,
            title = '',
            result = '',
            i;

        for (i in line) {
            var c = line[i];

            if (c === '(' && !isTitle) {
                isTitle = true;
            } else if (c === ')' && isTitle) {
                isTitle = false;
                break;
            } else if (isTitle) {
                title += c;
            }
        }

        result = models[title] + '';

        if (result === 'true') {
            return true;
        } else if (result === 'false') {
            return false;
        }
    }

    // @@text
    function parseEscaped(n) {
        var index = +n,
            line = args[index] + '',
            outputStr = '',
            isEscaped = false,
            prevChr = '',
            i = 0;

        for (i in line) {
            var c = line[i];
            var c2 = line[+i + 1];

            if (c === '@') {
                if (c2 === '@') {
                    continue;
                } else {
                    outputStr += c;
                }
            } else {
                outputStr += c;
            }
        }

        output.push(outputStr);
    }

    // standard model model:value
    function parseModelValue(str, counter, indent) {
        var line = str + '',
            outputStr = '',
            isModel = false,
            title = '',
            i = 0;
        // counter = 0;

        while (true) {
            for (i in line) {
                var c = line[i];

                if (c === '@') {
                    isModel = true;
                } else if (isModel && (c === ' ' || c === '<')) {
                    outputStr += models[title][+counter];
                    outputStr += c;
                    isModel = false;
                } else if (isModel) {
                    title += c;
                } else {
                    outputStr += c;
                }
            }

            output.push(outputStr.slice(+indent));
            break;
            // counter += 1;

            // if (title === '') {
            //     break;
            // }

            // if (counter === models[title].length) {
            //     break;
            // }

            // title = '';
            // outputStr = '';
        }
    }

    function parseForeach(n) {
        var line = args[+n] + '',
            forModel = '',
            arrName = '',
            body = [],
            isModel = false,
            isArray = false,
            isStatement = false,
            word = '',
            i, j, k, c = '',
            index = +n;

        // get model and array
        for (i in line) {
            c = line[i];

            if (c === '(') {
                isStatement = true;
            } else if (isStatement && (c === ' ' || c === ')')) {
                // evaluate word
                // If it s a  model or array add to list
                if (isModel) {
                    models[word] = [];
                    forModel = word;
                } else if (isArray) {
                    models[forModel] = models[word].slice();
                    arrName = word;
                }

                // If not than check what it is.
                if (word === 'var') {
                    isModel = true;
                } else if (word === 'in') {
                    isArray = true;
                } else {
                    isModel = false;
                    isArray = false;
                }

                word = '';
            } else if (c === ')') {
                isStatement = false;
            } else if (isStatement) {
                word += c;
            }
        }

        // get body
        index += 1;
        while (args[index].trim() !== '}') {
            body.push(args[index]);
            index += 1;
        }

        // generate
        for (j in models[forModel]) {
            for (k in body) {
                if ((body[k] + '').indexOf('@' + forModel) >= 0) {
                    parseModelValue(body[k] + '', j, 4);
                } else {
                    parseModelValue(body[k] + '', 0, 4);
                }
            }
        }

        return index;
    }

    function parseForeachValue(n) {
        var line = args[+n] + '',
            outputStr = '',
            isModel = false,
            title = '',
            i = 0, j = 0,
            arrName = '';

        // Find arrName


        // Fill values from array
        for (j in models[arrName]) {
            for (i in line) {
                var c = line[i];

                if (c === '@') {
                    isModel = true;
                } else if (isModel && (c === ' ' || c === '<')) {
                    outputStr += models[arrName][j];
                    outputStr += c;
                    isModel = false;
                } else if (isModel) {
                    title += c;
                } else {
                    outputStr += c;
                }
            }

            output.push(outputStr);
        }
    }

    // read models
    for (i = 1; i < +args[0] + 1; i += 1) {
        line = args[i] + '';
        parseModel(line);
    }

    // replace
    var numberOfLines = +args[+args[0] + 1] + +args[0] + 1;
    for (i = 2 + +args[0]; i < numberOfLines; i += 1) {
        var line = args[i] + '',
            isKey = false,
            trimmedLine = '';

        if (ifStatementResult === false && line.trim() === '}') {
            ifStatementResult = true;
            continue;
        } else if (ifStatementResult === false) {
            continue;
        }

        // Get key 
        trimmedLine = line.trim();
        for (var chr in line) {
            var c = trimmedLine[chr];

            if (c === '@' && !isKey) {
                isKey = true;
                continue;
            } else if (c === separators[0] || c === separators[1] || c === '(') {

                if (isKey) {
                    isKey = false;
                    break;
                }

            } else if (isKey) {
                key += c;
            }
        }

        if (key === '') {
            output.push(line);
            continue;
        } else if (key === 'section') {
            // Parse section.
            // Add to models.
            // Return the number of the last line of input read.
            i = parseSection(i);
        } else if (key === 'if') {
            // Parse lines till a }
            ifStatementResult = parseIf(i);
        } else if (key === 'foreach') {
            // Parse lines till a }
            i = parseForeach(i);
        } else if (key === 'renderSection') {
            // Parse the line and insert the section
            parseRenderSection(i);
        } else if (key.charAt(0) === '@') {
            // Escaped, remove one @ and do nothing
            parseEscaped(i);
        } else {
            // Display value
            parseModelValue(line, 0, 0);
        }

        // Reset key.
        key = '';
    }

    console.log(output.join('\n'));
}

var test1 = [
    '6',
    'title:Telerik Academy',
    'showSubtitle:false',
    'subTitle:Free training',
    'showMarks:false',
    'marks:3,4,5,6',
    'students:Pesho,Gosho,Ivan',
    '42',
    '@section menu {',
    '<ul id="menu">',
    '    <li>Home</li>',
    '    <li>About us</li>',
    '</ul>',
    '}',
    '@section footer {',
    '<footer>',
    '    Copyright Telerik Academy 2014',
    '</footer>',
    '}',
    '<!DOCTYPE html>',
    '<html>',
    '<head>',
    '    <title>Telerik Academy</title>',
    '</head>',
    '<body>',
    '    @renderSection("menu")',
    '',
    '    <h1>@title</h1>',
    '    @if (showSubtitle) {',
    '        <h2>@subTitle</h2>',
    '        <div>@@JustNormalTextWithDoubleKliomba ;)</div>',
    '    }',
    '',
    '    <ul>',
    '        @foreach (var student in students) {',
    '            <li>',
    '                @student ',
    '            </li>',
    '            <li>Multiline @title</li>',
    '        }',
    '    </ul>',
    '    @if (showMarks) {',
    '        <div>',
    '            @marks ',
    '        </div>',
    '    }',
    '',
    '    @renderSection("footer")',
    '</body>',
    '</html>'
];

solve(test1);