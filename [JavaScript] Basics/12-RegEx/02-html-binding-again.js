function solve(args) {
    const options = JSON.parse(args[0]);

    let input = (args[1] + '').replace(/'/, '"');

    let regexStr = `data-bind-(.*?)="(.*?)"`;
    let matchOption = new RegExp(regexStr, 'img');

    let matches = matchOption.exec(input); // the 'money' line regexp.exec(str) isntead of str.match(regexp)

    while (matches) {

        let index = input.indexOf('>');

        if ((matches[1] + '').toLowerCase() === 'content') {

            input = `${input.slice(0, index + 1)}${options[matches[2]]}${input.slice(index + 1)}`;

        } else {

            if (input[index - 1] === '/') {
                index -= 1;
            }

            input = `${input.slice(0, index)} ${matches[1]}="${options[matches[2]]}"${input.slice(index)}`;
        }

        matches = matchOption.exec(input);
    }
    console.log(input);
}

module.exports = {
    solve
};