(function (parent) {
    var student = (function (parent) {
        var student = Object.create(parent),
            _id;

        Object.defineProperties(student, {
            init: {
                value: function (name, age, id) {
                    parent.init.call(this, name, age);
                    this.id = id;
                    return this;
                }
            },
            id: {
                get: function () {
                    return _id;
                },
                set: function (value) {
                    _id = value;
                }
            }
        });

        return student;
    } (parent));

    module.exports = student;
} (require('./person')));

(function () {
    var student = require('./student');
    var stu = Object.create(student).init('name', 15, 33);
    console.log(stu.id);
} ());