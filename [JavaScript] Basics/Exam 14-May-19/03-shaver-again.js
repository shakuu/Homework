function solve(args) {
    let keyValuePairsCount = +args[0],
        keyValuePairsInput = args
            .splice(0, keyValuePairsCount + 1)
            .slice(1),
        keys = [],
        sections = [];

    // Parse key-value pairs. storage[key] = value;
    keyValuePairsInput.forEach(pair => {
        let pairAsArray = pair
            .split(':')
            .map(str => {
                return str
                    .split(',')
                    .map(s => {
                        return s.trim().replace(/\s\s+/g, ' ');
                    });
            });
        keys[pairAsArray[0]] = pairAsArray[1];
    });

    // Parse each line of input.
    let output = [],
        toAddToOutput = [];

    // Regex matching each possible input.
    let matchKey = /@(.*?)[<| ]/,
        matchSectionOpen = /@section (.*?) {/,
        matchSectionRender = /@renderSection\("(.*?)"\)/,
        matchCondition = /@if \((.*?)\) {/,
        matchLoop = /@foreach \(var (.*?) in (.*?)\) {/,
        matchEscaped = /@@.*?[<| ]/,
        matchClosingBracket = /^(\s*)?}(\s*)?$/;

    // Iterate each line of input.
    for (let lineNr = 1; lineNr <= +args[0]; lineNr += 1) {
        let line = args[lineNr] + '';

        if (matchEscaped.test(line)) {
            // Remove the extra @ and add to output.
        } else if (matchKey.test(line)) {
            // Display the appropriate value.
        } else if (matchClosingBracket.test(line)) {
            // End of current scope
        } else if (matchSectionOpen.test(line)) {
            // Read section content into sections[]
        } else if (matchCondition.test(line)) {
            // Evaluate condition
        } else if (matchLoop.test(line)) {
            // Collect each line, then iterate them.
        } else if (matchSectionRender.test(line)) {
            // Display the appropriate section
        }

        console.log(`${lineNr} ${line}`);
    }
}

module.exports = {
    solve
};