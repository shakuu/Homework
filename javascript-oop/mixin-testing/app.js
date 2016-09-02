const Course = require('./models/course');
const test = new Course('title', [1, 2, 3]);

test.addStudent('az sym');
test.addStudent('toj e');
test.addStudent('nie sme');
test.submitHomework(1, 1);

console.log(test.getAllStudents());