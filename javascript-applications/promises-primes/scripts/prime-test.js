const primeTest = (() => {
    function primeTest(value) {
        return {
            isPrime: true,
            value: value
        };
    }

    return primeTest;
})();

module.exports = primeTest;