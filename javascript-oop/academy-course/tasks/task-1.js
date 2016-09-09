function solve() {
    function* IdGenerator() {
        let lastId = 0;
        while (true) {
            yield lastId += 1;
        }
    }

    const validator = (() => {
        const WHITESPACE_START = /^\s+/,
            WHITESPACE_END = /\s+$/,
            WHITESPACE_CONSECUTIVE = /\s\s+/;

        const STUDENT_NAME = /^[A-Z][a-z]*$/;

        return {
            validateIsNumber(value) {
                value = Number(value);
                if (isNaN(value)) {
                    throw new Error();
                }
            },
            validateIsString(value) {
                if (value === undefined) {
                    throw new Error();
                }

                if (typeof value !== 'string') {
                    throw new Error();
                }
            },
            validateTitle(value) {
                validator.validateIsString(value);

                if (value.length < 1) {
                    throw new Error();
                }

                if (WHITESPACE_START.test(value)) {
                    throw new Error();
                }

                if (WHITESPACE_END.test(value)) {
                    throw new Error();
                }

                if (WHITESPACE_CONSECUTIVE.test(value)) {
                    throw new Error();
                }
            },
            validateStudentName(value) {
                const names = value.split(' ');
                if (names.length !== 2) {
                    throw new Error();
                }

                names.forEach(name => {
                    if (!STUDENT_NAME.test(name)) {
                        throw new Error();
                    }
                });
            }
        };
    })();

    const studentIdGenerator = IdGenerator();
    var Course = {
        init: function (title, presentations) {
            validator.validateTitle(title);
            this.title = title;

            if (!Array.isArray(presentations) || presentations.length === 0) {
                throw new Error();
            }

            presentations.forEach(item => validator.validateTitle(item));
            this.presentations = presentations;

            this.students = [];

            return this;
        },
        addStudent: function (name) {
            validator.validateStudentName(name);
            const studentNames = name.split(' ');

            const nextId = studentIdGenerator.next().value;
            this.students[nextId] = {
                firstname: studentNames[0],
                lastname: studentNames[1],
                id: nextId
            };

            return nextId;
        },
        getAllStudents: function () {
            const data = [];
            this.students.forEach(student => {
                if (student.id) {
                    data.push({
                        firstname: student.firstname,
                        lastname: student.lastname,
                        id: student.id
                    });
                }
            });

            return data;
        },
        submitHomework: function (studentID, homeworkID) {
            validator.validateIsNumber(studentID);
            validator.validateIsNumber(homeworkID);

            if (homeworkID < 1 || this.presentations.length < homeworkID) {
                throw new Error();
            }

            if (!this.students[studentID]) {
                throw new Error();
            }

            const student = this.students[studentID];
            if (!student.homework) {
                student.homework = [];
            }

            student.homework[homeworkID] = true;
        },
        pushExamResults: function (results) {
            if (!Array.isArray(results)) {
                throw new Error();
            }

            const self = this;
            results.forEach(item => {
                if (item.StudentID === undefined || !item.score === undefined) {
                    throw new Error();
                }

                validator.validateIsNumber(item.score);
                validator.validateIsNumber(item.StudentID);

                if (self.students[item.StudentID] === undefined) {
                    throw new Error();
                }

                if (self.students[item.StudentID].score !== undefined) {
                    throw new Error();
                }

                self.students[item.StudentID].score = item.score;
            });

            this.students.forEach(student => {
                if (!student.score) {
                    student.score = 0;
                }
            });
        },
        getTopStudents: function () {
        }
    };

    return Course;
}


module.exports = solve;
