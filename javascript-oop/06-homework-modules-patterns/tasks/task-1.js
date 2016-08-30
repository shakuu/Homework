function solve() {
    var REGEX_CONSECUTIVE_WHITESPACE = /\s\s+/,
        REGEX_STARTS_WITH_WHITESPACE = /^\s+/,
        REGEX_ENDS_WITH_WHITESPACE = /\s+$/,
        REGEX_CAPITALIZED_NAME = /[A-Z][a-z]*/;

    var title,
        homework,
        lastId = 1;

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
            this.studentsById = [];
            this.examResults = [];
            this.studentHomeworks = [];

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
            this.studentsById[newStudent.id] = newStudent;

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

            if (!this.studentHomeworks[studentID]) {
                this.studentHomeworks[studentID] = 0;
            }

            this.studentHomeworks[studentID] += 1;
        },
        pushExamResults: function (results) {
            if (!results) {
                throw new Error();
            }

            if (!Array.isArray(results)) {
                throw new Error();
            }

            var self = this;
            results.forEach(function (result) {
                if (!result.score || !result.StudentID) {
                    throw new Error();
                }

                if (!(+result.score || result.score === 0)) {
                    throw new Error();
                }

                if (!(+result.StudentID || result.StudentID === 0)) {
                    throw new Error();
                }

                if (!self.studentsById[+result.StudentID]) {
                    throw new Error();
                }

                if (self.examResults[+result.StudentID]) {
                    throw new Error();
                }

                self.examResults[result.StudentID] = result;
            });

            this.students.forEach(function (student) {
                if (!self.examResults[student.id]) {
                    self.examResults[student.id] = {
                        StudentID: student.id,
                        score: 0
                    };
                }
            });
        },
        getTopStudents: function () {
            var calculateScores = [],
                topTenStudents = [],
                i;

            for (i = 0; i < this.students.length; i += 1) {
                var id = this.students[i].id,
                    examScore = this.examResults[id].score || 0,
                    homeworkCount = this.studentHomeworks[id] || 0,
                    score = (0.75 * examScore) + (0.25 * (homeworkCount / 5));

                calculateScores[id] = {
                    score: score,
                    id: id
                };
            }

            calculateScores.sort(function (a, b) {
                return b.score - a.score;
            });

            for (i = 0; i < 10; i += 1) {
                if (calculateScores[i]) {
                    topTenStudents.push(this.studentsById[calculateScores[i].id]);
                } else {
                    break;
                }
            }

            return topTenStudents;
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

module.exports = solve;