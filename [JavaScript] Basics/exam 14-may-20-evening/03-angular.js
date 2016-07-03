function solve(args) {
    var numberOfModels = +args[0],
        numberOfLines = +args[numberOfModels + 1];

    var inputModels = args.splice(0, numberOfModels + 1).slice(1);

    var output = [],
        models = [],
        templates = [];

    var i, j;

    // Read Models
    var matchModels = /(.*?)-(.*)/;
    for (i in inputModels) {
        var match = inputModels[i].match(matchModels);
        models[match[1]] = (match[2] + '').split(';');
    }

    // Parse the text
    // Match each possible command 
    var matchModel = /<nk-model>(.*?)<\/nk-model>/,
        matchNewTemplate = /<nk-template name="(.*?)">/,
        matchEndNewTemplate = /<\/nk-template>/,
        matchRenderTemplate = /<nk-template render="(.*?)" \/>/,
        matchRepeatOpen = /<nk-repeat for="(.*?) in (.*?)">/,
        matchRepeatClose = /<\/nk-repeat>/,
        matchConditionOpen = /<nk-if condition="(.*?)">/,
        matchConditionClose = /<\/nk-if>/,
        matchEscaped = /\{\{<nk-.*?>\}\}/;

    // States
    var isNewTemaplate = false,
        isRepeat = false,
        isCondition = false,
        toDisplay = true;

    // Store
    var currentCondition = [],
        currentRepeat = [],
        modelsRepeat = [],
        currentRepeatModel = '',
        currentTemplate = '',
        toDisplayLines = [];

    // Replace Mode tag
    function replaceModel(line) {
        var match = (line + '').match(matchModel);

        if (!models[match[1]]) {
            return line;
        } else {
            return (line + '').replace(matchModel, models[match[1]]);
        }
    }

    // Insert Template
    function insertTemplate(line) {

        var match = (line + '').match(matchRenderTemplate);
        var template = templates[match[1]],
            index, result = [];

        for (index in template) {
            result.push(template[index]);
        }

        return result;
    }

    // Evaluate the condition. Return toDisplay true or false.
    function evaluateCondition(line) {
        var match = (line + '').match(matchConditionOpen);
        return models[match[1]][0] === 'true';
    }

    // Evaluate repeat tag, add new model referring to the appropriate array
    function evaluateRepeat(line) {
        var match = (line + '').match(matchRepeatOpen);
        currentRepeatModel = match[1];
        modelsRepeat[match[1]] = models[match[2]];
    }

    // Insert all repeated lines into output
    function insertRepeatSection(lines) {
        var i, j, result = [];

        for (i in modelsRepeat[currentRepeatModel]) {
            for (j in lines) {
                var curLine = lines[j] + '';

                if (matchModel.test(curLine) && !matchEscaped.test(curLine)) {
                    curLine = curLine.replace(matchModel, modelsRepeat[currentRepeatModel][i]);
                }

                result.push(curLine);
            }
        }

        return result;
    }

    // Parse the tags and look for matches
    for (i = 1; i <= +args[0]; i += 1) {
        var line = args[i] + '';

        // If the result of the condition was false.
        // Skip lines until the end of the condition tag.
        if (matchConditionClose.test(line)) {
            toDisplay = true;
            continue;
        } else if (!toDisplay) {
            continue;
        }

        if (matchEscaped.test(line)) {
            // Remove the escaped symbols and push the line.
            line = line.replace(/\{/g, '');
            line = line.replace(/\}/g, '');
            toDisplayLines.push(line);
        } else if (matchModel.test(line)) {
            // Insert model.
            toDisplayLines.push(replaceModel(line));
        } else if (matchNewTemplate.test(line)) {
            // Parse new template.
            currentTemplate = line.match(matchNewTemplate)[1];
            templates[currentTemplate] = [];
            isNewTemaplate = true;
        } else if (matchRenderTemplate.test(line)) {
            // Display Template
            toDisplayLines = insertTemplate(line);
        } else if (matchRepeatOpen.test(line)) {
            // Evaluate repeat , add new model
            evaluateRepeat(line);
            isRepeat = true;
        } else if (matchConditionOpen.test(line)) {
            // Evaluate the condition.
            toDisplay = evaluateCondition(line);
        } else if (matchEndNewTemplate.test(line)) {
            // Close the current template.
            isNewTemaplate = false;
            currentTemplate = '';
        } else if (isNewTemaplate) {
            // Add lines to the template until the EndNewTemplate tag is met.
            templates[currentTemplate].push(line);
        } else if (matchRepeatClose.test(line)) {
            // Evaluate gathered lines
            toDisplayLines = insertRepeatSection(currentRepeat);
            currentRepeatModel = '';
            currentRepeat = [];
            isRepeat = false;
        } else {
            toDisplayLines.push(line);
        }

        // Display toDisplayLines[] - add them to output.
        if (isRepeat) {
            for (j in toDisplayLines) {
                currentRepeat.push(toDisplayLines[j]);
            }
        } else {
            for (j in toDisplayLines) {
                output.push(toDisplayLines[j]);
            }
        }

        toDisplayLines = [];
    }

    console.log(output.join('\r\n'));
}

module.exports = {
    solve
};