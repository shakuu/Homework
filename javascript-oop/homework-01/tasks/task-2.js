/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function findPrimes(start, end) {
	var primes = [],
		i, j, bound, isPrime;

	if (+start || start === 0) {
		start = +start;
	} else {
		throw new Error();
	}

	if (+end || end === 0) {
		end = +end;
	} else {
		throw new Error();
	}
	
	for (i = Math.max(+start, 2); i <= +end; i += 1) {
		isPrime = true;
		bound = Math.floor(Math.sqrt(i));

		for (j = 2; j <= bound; j += 1) {
			if (i % j === 0) {
				isPrime = false;
				break;
			}
		}

		if (isPrime) {
			primes.push(i);
		}
	}

	return primes;
}
findPrimes(0, 5);
module.exports = findPrimes;
