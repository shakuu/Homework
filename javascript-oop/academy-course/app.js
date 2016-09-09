var Course = require('./tasks/task-1')();

var jsoop = Object.create(Course)
    .init('Asd', ['Asdf']);
jsoop.addStudent('A' + ' ' + 'B');
jsoop.addStudent('C' + ' ' + 'D');
function test() {
    jsoop.pushExamResults([{ StudentID: 1, score: 4 }, { StudentID: 2, score: 5 }])
}
test();