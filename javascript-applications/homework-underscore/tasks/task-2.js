/*
Create a function that:
*   Takes an array of students
    *   Each student has a `firstName`, `lastName` and `age` properties
*   **finds** the students whose age is between 18 and 24
*   **prints**  the fullname of found students, sorted lexicographically ascending
    *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   **Use underscore.js for all operations**
*/

function solve() {
    'use strict';
    return function (students) {
        const matching = _.chain(students)
            .filter(std => {
                const isEligible = 18 <= std.age && std.age <= 24;
                return isEligible;
            })
            .map(std => `${std.firstName} ${std.lastName}`)
            .sortBy(std => std)
            .each(std => console.log(std));

    };
}

module.exports = solve;
