function solve(args) {
    var counter = 1,
        numbers = args.slice(1).map(Number);

    for (var i = 1; i < numbers.length; i += 1) {
        if (numbers[i] < numbers[i - 1]) {
            counter += 1;
        }
    }

    console.log(counter);
}

module.exports = {
    solve
};