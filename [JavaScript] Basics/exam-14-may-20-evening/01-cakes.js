function solve(args) {
    var cash = +args[0],
        cakes = args.slice(1).map(Number),
        max = 0,
        cost = 0;

    function evaluate(cost, mod) {
        if (+cost > +cash) {
            return;
        }

        if (cost > max) {
            max = cost;
        }

        if (+mod < 1) {
            evaluate(+cost + cakes[0], 0)
        }

        if (+mod < 2) {
            evaluate(+cost + cakes[1], 1)
        }

        if (+mod < 3) {
            evaluate(+cost + cakes[2], 2)

        }
    }

    evaluate(0, 0);
    console.log(max);
}

var test1 = [
    '110',
    '13',
    '15',
    '17'
];

var test2 = [
    '20',
    '11',
    '200',
    '300'
];

solve(test2);