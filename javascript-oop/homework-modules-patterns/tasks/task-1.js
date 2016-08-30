/* Task Description */
/* 
* Create a module for a Telerik Academy course
  * The course has a title and presentations
    * Each presentation also has a title
    * There is a homework for each presentation
  * There is a set of students listed for the course
    * Each student has firstname, lastname and an ID
      * IDs must be unique integer numbers which are at least 1
  * Each student can submit a homework for each presentation in the course
  * Create method init
    * Accepts a string - course title
    * Accepts an array of strings - presentation titles
    * Throws if there is an invalid title
      * Titles do not start or end with spaces
      * Titles do not have consecutive spaces
      * Titles have at least one character
    * Throws if there are no presentations
  * Create method addStudent which lists a student for the course
    * Accepts a string in the format 'Firstname Lastname'
    * Throws if any of the names are not valid
      * Names start with an upper case letter
      * All other symbols in the name (if any) are lowercase letters
    * Generates a unique student ID and returns it
  * Create method getAllStudents that returns an array of students in the format:
    * {firstname: 'string', lastname: 'string', id: StudentID}
  * Create method submitHomework
    * Accepts studentID and homeworkID
      * homeworkID 1 is for the first presentation
      * homeworkID 2 is for the second one
      * ...
    * Throws if any of the IDs are invalid
  * Create method pushExamResults
    * Accepts an array of items in the format {StudentID: ..., Score: ...}
      * StudentIDs which are not listed get 0 points
    * Throw if there is an invalid StudentID
    * Throw if same StudentID is given more than once ( he tried to cheat (: )
    * Throw if Score is not a number
  * Create method getTopStudents which returns an array of the top 10 performing students
    * Array must be sorted from best to worst
    * If there are less than 10, return them all
    * The final score that is used to calculate the top performing students is done as follows:
      * 75% of the exam result
      * 25% the submitted homework (count of submitted homeworks / count of all homeworks) for the course
*/

function solve() {
    var REGEX_CONSECUTIVE_WHITESPACE = /\s\s+/,
        REGEX_STARTS_WITH_WHITESPACE = /^\s+/,
        REGEX_ENDS_WITH_WHITESPACE = /\s+$/,
        REGEX_CAPITALIZED_NAME = /[A-Z][a-z]*/;

    var title,
        homework,
        presentations = [],
        // students = [],
        lastId = 0;

    var student = {
        init: function (id, firstname, lastname) {
            this.firstname = firstname;
            this.lastname = lastname;
            this.id = id;

            return this;
        }
    };

    var presentation = {
        init: function (title, homework) {
            this.title = title;
            this.homework = homework;
            return this;
        }
    };

    var Course = {
        init: function (title, presentations) {
            if (!presentations) {
                throw new Error();
            }

            if (presentations.length === 0) {
                throw new Error();
            }

            presentations.forEach(function (presentation) {
                validateString(presentation);
            });

            validateString(title);

            this.title = title;
            this.presentations = presentations;
            this.students = [];
            
            return this;
        },
        addStudent: function (name) {
            var studentNames;

            if (!name) {
                throw new Error();
            }

            if (typeof name !== 'string') {
                throw new Error();
            }

            studentNames = name.split(' ');

            if (studentNames.length !== 2) {
                throw new Error();
            }

            studentNames.forEach(function (name) {
                if (name.length < 1) {
                    throw new Error();
                }

                if (!REGEX_CAPITALIZED_NAME.test(name)) {
                    throw new Error();
                }

                return name.trim();
            });

            var newId = lastId++;
            var newStudent = Object.create(student).init(newId, studentNames[0], studentNames[1]);
            this.students.push(newStudent);

            return newId;
        },
        getAllStudents: function () {
            var allStudents = JSON.parse(JSON.stringify(this.students));
            return allStudents;
        },
        submitHomework: function (studentID, homeworkID) {
        },
        pushExamResults: function (results) {
        },
        getTopStudents: function () {
        }
    };

    function validateString(str) {
        if (typeof str !== 'string') {
            throw new Error();
        }

        if (str === '') {
            throw new Error();
        }

        if (REGEX_CONSECUTIVE_WHITESPACE.test(str)) {
            throw new Error();
        }

        if (REGEX_STARTS_WITH_WHITESPACE.test(str)) {
            throw new Error();
        }

        if (REGEX_ENDS_WITH_WHITESPACE.test(str)) {
            throw new Error();
        }
    }

    return Course;
}
var Course = solve();
var course = Object.create(Course).init('Ar', ['Moulds detonate tunnel', 'Miners handed cabbages to the delight of children']);
course.addStudent('Az Sym');
console.log(course.getAllStudents());

module.exports = solve;