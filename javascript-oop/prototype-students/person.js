(function () {
    var person = (function () {
        var person = {},
            _name,
            _age;

        Object.defineProperties(person, {
            init: {
                value: function (name, age) {
                    this.name = name;
                    this.age = age;
                    return this;
                }
            },
            name: {
                get: function () {
                    return _name;
                },
                set: function (value) {
                    _name = value;
                }
            },
            age: {
                get: function () {
                    return _age;
                },
                set: function (value) {
                    _age = value;
                }
            }
        });

        return person;
    } ());

    module.exports = person;
} ());