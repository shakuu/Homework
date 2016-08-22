function Animal() {
    var Animal = (function () {
        var _name,
            _age;

        function Constructor(name, age) {
            _name = name;
            _age = age;
        }

        Object.defineProperty(Constructor.prototype, 'name', {
            get: function () {
                return _name;
            },
            set: function (name) {
                if (validateValueInRange(name, 2, 32)) {
                    _name = name;
                }
            }
        });

        Object.defineProperty(Constructor.prototype, "age", {
            get: function () {
                return _age;
            },
            set: function (age) {
                if (+age || age === 0) {
                    if (validateValueInRange(age, 0, 15)) {
                        _age = +age;
                    }
                }
            }
        });

        Constructor.prototype.toString = function () {
            return _name + ' ' + _age;
        };

        function validateValueInRange(value, min, max) {
            if (!(+value || value === 0)) {
                throw new Error();
            }
            if (!(+min || min === 0)) {
                throw new Error();
            }
            if (!(+max || max === 0)) {
                throw new Error();
            }

            if (min <= value && value <= max) {
                return true;
            } else {
                throw new Error();
            }
        }

        return Constructor;
    } ());
    return Animal;
}
module.exports = Animal;