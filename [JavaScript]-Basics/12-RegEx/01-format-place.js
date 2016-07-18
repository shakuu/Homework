function solve(args) {
    const options = JSON.parse(args[0]);

    let inputString = args[1] + '',
        matchProps = /#\{(.*?) \}/g;

    for (let item in options) {
        inputString = inputString
            .replace(new RegExp(`#{${item}}`, 'g'), options[item]);

    }
    
    console.log(inputString);
}


module.exports = {
    solve
};