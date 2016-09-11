/* 
Create a function that:
*   Takes an array of students
    *   Each student has:
        *   `firstName`, `lastName`, `age` and `marks` properties
        *   `marks` is an array of decimal numbers representing the marks         
*   **finds** the student with highest average mark (there will be only one)
*   **prints** to the console  'FOUND_STUDENT_FULLNAME has an average score of MARK_OF_THE_STUDENT'
    *   fullname is the concatenation of `firstName`, ' ' (empty space) and `lastName`
*   **Use underscore.js for all operations**
*/
const _ = require('underscore');
function solve() {
    return function (students) {
        const top = _.chain(students)
            .each(std => std.marks = _.reduce(std.marks, (a, b) => a + b) / std.marks.length, 0)
            .sortBy(std => std.marks)
            .reverse()
            .first()
            .value();

        const result = `${top.firstName} ${top.lastName} has an average score of ${top.marks}`;
        console.log(result);
    };
}

module.exports = solve;
