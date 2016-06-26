function solve(args) {
    var input = args,
        models = [],
        separators = [' ', '<'],
        i,
        line,
        key = '',
        isKey = false;;

    function parseModel(str) {
        var line = str + '',
            index = 0,
            title = '',
            value = '',
            len;

        // Determine if it s a @section

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

    // read models
    for (i = 1; i < +args[0] + 1; i += 1) {
        line = args[i] + '';
        parseModel(line);
    }

    // replace
    var numberOfLines = args[0] + 1;
    for (i = 2 + args[0]; i < numberOfLines; i += 1) {
        line = args[i] + '';
        isKey = false;

        // Get key 
        for (var c in line) {
            if (c === '@') {
                isKey = true;
                continue;
            } else if (c === separators[0] || c === separators[1]) {
                isKey = false;
            } else if (isKey) {
                key += c;
            }
        }

        // Determine which type of key it is
        // 1. Value
        // 2. Condition
        // 3. Render section
        // 4. Loop
        // 5. Escape
    }
}

var test1 = [
    '6',
    'title:Telerik Academy',
    'showSubtitle:true',
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