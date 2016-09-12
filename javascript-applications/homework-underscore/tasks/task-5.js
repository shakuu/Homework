/* 
Create a function that:
*   **Takes** an array of animals
    *   Each animal has propeties `name`, `species` and `legsCount`
*   **finds** and **prints** the total number of legs to the console in the format:
    *   "Total number of legs: TOTAL_NUMBER_OF_LEGS"
*   **Use underscore.js for all operations**
*/
const _ = require('underscore');

function solve() {
    'use strict()';
    return function (animals) {
        const legs = _.chain(animals)
            .map(animal => animal.legsCount)
            .reduce((a, b) => a + b, 0)
            .value();

        const result = `Total number of legs: ${legs}`;
        console.log(result);
    };
}

module.exports = solve;
