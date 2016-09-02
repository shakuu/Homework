const StorageProviderMixin = require('../mixins/storage-provider-mixin');
const Homework = require('./homework');
const Student = require('./student');

class Course extends StorageProviderMixin(Object) {
    constructor(title, presentations) {
        super();

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
        const student = this.getItemById(studentId, 'Student')[0];
        student.homework.assignments.filter(hw => hw.presentationId === homeworkId)[0].status = true;
        this.getItemById(studentId, 'Student', student);
    }
}

module.exports = Course;
