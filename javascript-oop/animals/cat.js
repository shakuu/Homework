(function () {
    var Cat = (function () {
        var Animal = require('./animal')(),
        
            ALLOWED_COLORS = ['red', 'white', 'purple'],

            _color;

        function Constructor(name, age, color) {
            Animal.call(this, name, age);
            this.color = color;
        }

        Constructor.prototype = Object.create(Animal.prototype);
        Constructor.prototype.toString = function () {
            var result = Animal.prototype.toString.call(this);
            return result + ' ' + _color;
        };

        Object.defineProperty(Constructor.prototype, 'color', {
            get: function () {
                return _color;
            },
            set: function (color) {
                if (validateColor(color)) {
                    _color = color;
                }
            }
        });

        function validateColor(color) {
            if (ALLOWED_COLORS.indexOf(color) >= 0) {
                return true;
            } else {
                throw new Error();
            }
        }

        return Constructor;
    } ());

    module.exports = Cat;
} ());

(function () {
    var Cat = require('./cat');
    var kittu = new Cat('name', 14, 'red');
    console.log(kittu.toString());
} ());