function solve(args) {
    var start = 0,
        end = 0,
        sum = 0,
        maxSum = Number.MIN_SAFE_INTEGER,
        i;

    var numbers = args.slice(1).map(Number);
    // Start Element
    for (start = 0; start < numbers.length; start += 1) {
        // End Element
        for (end = start; end < numbers.length; end += 1) {
            sum = 0;
            // Sum everything inbetween
            // Sum of a single element is allowed
            for (i = start; i <= end; i += 1) {
                sum += +numbers[i];
            }

            maxSum = sum > maxSum ? sum : maxSum;
        }
    }

    console.log(maxSum);
}

module.exports = {
    solve
};