function solve(args) {
    let matchAnchorTags = /<a href=".*?">.*?<\/a>/ig,
        matchExtractLable = /<a href="(.*?)">(.*?)<\/a>/,
        matches = [],
        replacementStrings = [];

    matches =
        args[0]
            .match(matchAnchorTags);

    replacementStrings =
        matches
            .map(m => {
                var match = m.match(matchExtractLable);
                return '[' + match[2] + '](' + match[1] + ')';
            });

    let len = matches.length;
    for (let i = 0; i < len; i += 1) {
        args[0] = args[0].replace(matches[i], replacementStrings[i]);
    }

    console.log(args[0]);
}

let test1 = [
    '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>'
];

solve(test1);