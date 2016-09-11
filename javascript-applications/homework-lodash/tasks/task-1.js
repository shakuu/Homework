
/* 
Create a function that:
*   Takes an array of students
    *   Each student has a `firstName` and `lastName` properties
*   **Finds** all students whose `firstName` is before their `lastName` alphabetically
*   Then **sorts** them in descending order by fullname
    *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   Then **prints** the fullname of found students to the console
*   **Use underscore.js for all operations**
*/
const _ = require('underscore');

function solve() {
    'use strict';
    return function (students) {
        students = _.chain(students)
            .filter(std => std.firstName < std.lastName)
            .map(std => `${std.firstName} ${std.lastName}`)
            .sortBy(std => std)
            .value()
            .reverse();

        students.forEach(std => console.log(std));
    };
}

module.exports = solve;