function solve(s) {
    var vehicles = +s,
        wheelsT = 10,
        wheelsC = 4,
        wheelsTrike = 3,
        counter = 0;

    function find(n, mod) {
        // End on match or miss
        if (n === 0) {
            counter += 1;
            return;
        } else if (n < 0) {
            return;
        }

        if (+mod < 1) {
            find(+n - wheelsT, 0);
        }

        if (+mod < 2) {
            find(+n - wheelsC, 1);
        }

        if (+mod < 3) {
            find(+n - wheelsTrike, 2);
        }
    }

    find(vehicles, 0);
    console.log(counter);
}

solve(10);