function solve(args) {
    let scopeStack = [],
        output = '';

    scopeStack.push({
        "selector": null,
        "parent": null,
        "props": []
    });

    let currentSelector = scopeStack[0];

    function selectorExists(newSelector) {
        for (let index in scopeStack) {
            if (scopeStack[index].selector === (newSelector.selector + '')) {
                return index;
            }
        }

        return -1;
    }

    function propertyExists(scope, property) {
        for (let index in scope.props) {
            if (scope.props[index].name + '' === property.name + '') {
                return index;
            }
        }

        return -1;
    }

    for (let lineNr in args) {
        let line = args[lineNr].replace(/\s\s+/g, ' ').trim() + '';

        if (line[line.length - 1] === '{') {
            // It is a selector
            line = line.slice(0, line.length - 1).trim();

            let space = ' ';
            if (currentSelector.selector &&
                (currentSelector.selector[currentSelector.selector.length - 1] === '>' ||
                    currentSelector.selector[currentSelector.selector.length - 1] === '+' ||
                    currentSelector.selector[currentSelector.selector.length - 1] === '~')) {
                space = '';
            }

            if (line.indexOf('>') >= 0 || line.indexOf('+') >= 0 || line.indexOf('~') >= 0) {
                line = line.replace(/\s/g, '');
            }

            let newSelector = {
                "selector": currentSelector.selector ? `${currentSelector.selector}${space}${line}` : line,
                "parent": currentSelector,
                "props": []
            };

            // Check if exists
            let index = selectorExists(newSelector);

            if (index >= 0) {
                currentSelector = scopeStack[index];
            } else {
                scopeStack.push(newSelector);
                currentSelector = scopeStack[scopeStack.length - 1];
            }

        } else if (line[line.length - 1] === ';') {
            // It is a property
            // If property exists change it's value
            line = line.replace(/\s/g, '');

            let propAsArray = line
                .slice(0, line.length - 1)
                .split(':');

            let newProp = {
                "name": propAsArray[0],
                "value": propAsArray[1]
            };

            let index = propertyExists(currentSelector, newProp);

            if (index >= 0) {
                currentSelector.props.splice(index, 1);
            }

            currentSelector.props.push(newProp);

        } else if ((line.replace(/\s/g, ''))[line.length - 1] === '}') {
            // It is a closing selector scope bracket
            currentSelector = currentSelector.parent;
        }
    }

    for (let scope of scopeStack) {
        if (!scope.selector) {
            continue;
        }

        let currentLine = `${scope.selector}{`;

        for (let prop of scope.props) {
            currentLine += `${prop.name}:${prop.value};`;
        }

        currentLine = currentLine.slice(0, currentLine.length - 1) + '}';
        output += currentLine;
    }

    console.log(output);

    // // Testing print
    // for (let scope of scopeStack) {
    //     console.log(scope);
    // }
}

module.exports = {
    solve
};