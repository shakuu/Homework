/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/
function solve() {

	function sum(array) {
		var sum;

		if (!Array.isArray(array)) {
			throw new Error();
		}

		if (array.length === 0) {
			return null;
		}

		sum = 0;
		array.forEach(function (element) {
			if (+element) {
				sum += +element;
			} else {
				throw new Error();
			}
		});

		return sum;
	}

	module.exports = sum;
}