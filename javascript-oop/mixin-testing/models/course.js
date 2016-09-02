const StorageProviderMixin = require('../mixins/storage-provider-mixin');
const Homework = require('./homework');
const Student = require('./student');

const STARTS_WITH_WHITESPACE = /^\s+/;
const ENDS_WITH_WHITESPACE = /\s$/;
const VALID_NAME = /^[A-Z][a-z]*$/;

class Course extends StorageProviderMixin(Object) {
    constructor(title, presentations) {
        super();

        if (!presentations) {
            throw new Error();
        }

        if (!Array.isArray(presentations)) {
            throw new Error();
        }

        if (presentations.length === 0) {
            throw new Error();
        }

        presentations.forEach(presentation => {
            if (typeof presentation !== 'string') {
                throw new Error();
            }

            if (presentation.length === 0) {
                throw new Error();
            }

            if (STARTS_WITH_WHITESPACE.test(presentation)) {
                throw new Error();
            }

            if (ENDS_WITH_WHITESPACE.test(presentation)) {
                throw new Error();
            }
        })

        this.title = title;
        this.presentations = presentations;
    }

    get title() {
        return this._title;
    }

    set title(title) {
        this._title = title;
    }

    get presentations() {
        return this._presentations;
    }

    set presentations(presentations) {
        this._presentations = presentations;
    }

    addStudent(name) {
        const names = name.split(' '),
            homework = new Homework(this.presentations.length),
            student = new Student(...names, homework);

        if (names.length < 2) {
            throw new Error();
        }

        names.forEach(name => {
            if (!VALID_NAME.test(name)) {
                throw new Error();
            }
        });

        var generatedId = this.addItem(student);
        return generatedId;
    }

    getAllStudents() {
        const allStudents = this.getAllItems('Student'),
            formattedOutput = [];

        allStudents.forEach(student => {
            formattedOutput.push({
                firstname: student.firstname,
                lastname: student.lastname,
                id: student.id
            });
        });

        return formattedOutput;
    }

    submitHomework(studentId, homeworkId) {
        let student = this.getItemById(studentId, 'Student');
        if (student.length === 0 || student.length > 1) {
            throw new Error();
        } else {
            student = student[0];
        }

        let homework = student.homework.assignments.filter(hw => hw.presentationId === homeworkId);
        if (homework.length === 0 || homework.length > 1) {
            throw new Error();
        } else {
            homework[0].status = true;
        }

        this.setItemById(studentId, 'Student', student);
    }
}

module.exports = Course;
