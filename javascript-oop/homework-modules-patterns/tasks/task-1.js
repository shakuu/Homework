function solve() {
    var REGEX_CONSECUTIVE_WHITESPACE = /\s\s+/,
        REGEX_STARTS_WITH_WHITESPACE = /^\s+/,
        REGEX_ENDS_WITH_WHITESPACE = /\s+$/,
        REGEX_CAPITALIZED_NAME = /[A-Z][a-z]*/;

    var title,
        homework,
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
        init: function (title, inputPresentation) {
            if (!inputPresentation) {
                throw new Error();
            }

            if (!Array.isArray(inputPresentation)) {
                throw new Error();
            }

            if (inputPresentation.length === 0) {
                throw new Error();
            }

            inputPresentation.forEach(function (presentation) {
                validateString(presentation);
            });

            validateString(title);

            this.title = title;
            this.presentations = inputPresentation;
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
            var validStudentID = this.students.some(function (student) {
                return student.id === studentID;
            });

            if (!validStudentID) {
                throw new Error();
            }

            if ((homeworkID | 0) !== homeworkID) {
                throw new Error();
            }

            homeworkID -= 1;
            if (homeworkID < 0) {
                throw new Error();
            }

            if (this.presentations.length <= homeworkID) {
                throw new Error();
            }

            if (!this.presentations[homeworkID]) {
                this.presentations[homeworkID] = [];
            }
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
console.log(course.submitHomework(0, 1));

module.exports = solve;