function solve(args) {
    const upOpen = 'upcase',
        upClose = '/upcase',
        lowOpen = 'lowcase',
        lowClose = '/lowcase',
        orgOpen = 'orgcase',
        orgClose = '/orgcase',
        upScope = 'up',
        lowScope = 'low',
        orgScope = 'initial';

    let isTag = false,
        scopeStack = [],
        currentScope = orgScope,
        strLength = args[0].length,
        currentTag = '',
        output = '';

    for (let i = 0; i < strLength; i += 1) {
        let c = args[0][i] + '';

        if (c === '<') {
            isTag = true;
        } else if (c === '>') {
            isTag = false;
            // Evaluate Tag
            if (currentTag === upOpen) {
                scopeStack.push(currentScope);
                currentScope = upScope;
            } else if (currentTag === lowOpen) {
                scopeStack.push(currentScope);
                currentScope = lowScope;
            } else if (currentTag === orgOpen) {
                scopeStack.push(currentScope);
                currentScope = orgScope;
            } else if (currentTag === upClose) {
                currentScope = scopeStack.pop();
            } else if (currentTag === lowClose) {
                currentScope = scopeStack.pop();
            } else if (currentTag === orgClose) {
                currentScope = scopeStack.pop();
            } else {
                output += currentTag;
            }
            currentTag = '';
        } else if (isTag) {
            currentTag += c;
        } else if (!isTag) {
            if (currentScope === upScope) {
                output += c.toUpperCase();
            } else if (currentScope === lowScope) {
                output += c.toLowerCase();
            } else {
                output += c;
            }
        }
    }
    console.log(output);
}

let test1 = [
    'We are <orgcase>liViNg</orgcase> in a <upcase>yellow submarine</upcase>. We <orgcase>doN\'t</orgcase> have <lowcase>anything</lowcase> else.'
];

solve(test1);