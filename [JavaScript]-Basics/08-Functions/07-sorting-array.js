function solve(args) {
    console.log(
        numbers = args[1]
            .split(' ')
            .map(Number)
            .sort(function (a, b) {
                return a - b;
            })
            .join(' '));
}

solve(['10', '36 10 1 34 28 38 31 27 30 20']);