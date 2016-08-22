function Solve() {

    var Person = (function () {
        var _firstname,
            _lastname,
            _age;

        function validateNumericValueIsInRange(length, min, max) {
            min = min || 3;
            max = max || 20;
            length = length || 0;

            if (min <= length && length <= max) {
                return true;
            } else {
                throw new Error();
            }
        }

        function validateStringContainsOnlyLatinLetters(value) {
            var result;

            if (typeof value !== 'string') {
                return;
            }

            result = value.toLowerCase().split('').some(function (chr) {
                var charCode = chr.charCodeAt(0);
                return charCode < 97 || 122 < charCode;
            });

            if (result) {
                throw new Error();
            } else {
                return true;
            }
        }

        function Constructor(firstname, lastname, age) {
            if (validateNumericValueIsInRange(firstname.length, 3, 20) &&
                validateStringContainsOnlyLatinLetters(firstname)) {
                _firstname = firstname;
            }

            if (validateNumericValueIsInRange(lastname.length, 3, 20) &&
                validateStringContainsOnlyLatinLetters(lastname)) {
                _lastname = lastname;
            }

            if (validateNumericValueIsInRange(age, 0, 150)) {
                _age = age;
            }
        }

        Object.defineProperty(Constructor.prototype, "firstname", {
            get: function () {
                return _firstname;
            },
            set: function (firstname) {
                if (validateNumericValueIsInRange(firstname.length, 3, 20) &&
                    validateStringContainsOnlyLatinLetters(firstname)) {
                    _firstname = firstname;
                }
            }
        });

        Object.defineProperty(Constructor.prototype, "lastname", {
            get: function () {
                return _lastname;
            },
            set: function (lastname) {
                if (validateNumericValueIsInRange(lastname.length, 3, 20) &&
                    validateStringContainsOnlyLatinLetters(lastname)) {
                    _lastname = lastname;
                }
            }
        });

        Object.defineProperty(Constructor.prototype, "age", {
            get: function () {
                return _age;
            },
            set: function (age) {
                if (+age || age === 0) {
                    if (validateNumericValueIsInRange(age, 0, 150)) {
                        _age = age;
                    }
                } else {
                    throw new Error();
                }
            }
        });

        Object.defineProperty(Constructor.prototype, "fullname", {
            get: function () {
                return this.firstname + ' ' + this.lastname;
            },
            set: function (fullname) {
                var names = [];

                if (typeof fullname !== 'string') {
                    throw new Error();
                }

                names = fullname.split(' ');
                if (validateNumericValueIsInRange(names[0].length, 3, 20) &&
                    validateStringContainsOnlyLatinLetters(names[0])) {
                    _firstname = names[0];
                }

                if (validateNumericValueIsInRange(names[1].length, 3, 20) &&
                    validateStringContainsOnlyLatinLetters(names[1])) {
                    _lastname = names[1];
                }
            }
        });

        Constructor.prototype.introduce = function () {
            return 'Hello! My name is ' + this.fullname + ' and I am ' + this.age + '-years-old'
        };

        return Constructor;
    } ());

    return Person;
}

module.exports = Solve;