function solve(params) {
    var numbers = params[0].split(' ').map(Number),
        result = 0,
        counter = 0,
        len = numbers.length;


    for (var i = 1; i < len; i += 1) {
        counter += 1;

        if (numbers[i - 1] < numbers[i] && numbers[i] > numbers[i + 1]) {
            if (counter > result) {
                result = counter;
            }

            counter = 0;
        }
    }

    if (counter > result) {
        result = counter;
    }

    console.log(result);
}

solve(['5 1 7 4 8']);
solve(['5 1 7 6 3 6 4 2 3 8']);
solve(['10 1 2 3 4 5 4 3 2 1 10']);