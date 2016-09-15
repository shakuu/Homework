const PrimesStorage = (() => {
    let primes = [];
    class PrimesStorage {
        constructor() {
            primes = [];
        }

        resolve(candidate) {
            if (candidate.isPrime) {
                primes.push(candidate.value);
            }
        }

        all(){
            return primes;
        }
    }

    return PrimesStorage;
})();

module.exports = PrimesStorage;