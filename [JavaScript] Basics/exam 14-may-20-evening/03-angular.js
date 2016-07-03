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
    var matchModel = /<nk-model>(.*?)<\/nk-model>/,
        matchNewTemplate = /<nk-template name="(.*?)">/,
        matchEndNewTemplate = /<\/nk-template>/,
        matchRenderTemplate = /<nk-template render="(.*?)" \/>/,
        matchRepeatOpen = /<nk-repeat for="(.*?)">/,
        matchRepeatClose = /<\/nk-repeat>/,
        matchConditionOpen = /<nk-if condition="(.*?)">/,
        matchConditionClose = /<\/nk-if>/;

    for (i = 1; i < +args[0]; i += 1) {
        var line = args[i] + '';

        if (matchModel.test(line)) {
            // Insert model.
        } else if (matchNewTemplate.test(line)) {
            // Parse new template.
        } else if (matchRenderTemplate.test(line)) {
            // Display Template
        } else if (matchRepeatOpen.test(line)) {
            // Display Repeat.
        } else if (matchConditionOpen.test(line)) {
            // Display Condition.
        }
    }
}

module.exports = {
    solve
};