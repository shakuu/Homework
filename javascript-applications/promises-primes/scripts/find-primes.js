const PrimesStorage = require('./primes-storage');
const primeTest = require('./prime-test');

const findPrimes = (() => {
    const storage = new PrimesStorage();

    function findPrimes(start, end) {
        const result = {
            storage: storage,
            isComplete: false
        };

        const promises = [];
        for (let candidate = start; candidate <= end; candidate += 1) {
            const promise = new Promise((resolve, reject) => {
                const result = primeTest(candidate);
                resolve(result);
            });

            promise.then(storage.resolve);
            promises.push(promise);
        }

        Promise.all(promises).then(() => {
            result.isComplete = true;
        });

        return result;
    }

    return findPrimes;
})();

module.exports = findPrimes;