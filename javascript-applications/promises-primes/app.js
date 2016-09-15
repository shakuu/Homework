const findPrimes = require('./scripts/find-primes');

const res = findPrimes(1, 100000);
checkState();

function checkState() {
    if (!res.isComplete) {
        console.log(res);
        setTimeout(checkState, 1);
    }
    else {
        console.log(res.isComplete);
    }
}