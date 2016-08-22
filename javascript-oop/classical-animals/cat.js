(function (parent) {
    var Cat = (function (parent) {
        var ALLOWED_COLORS = ['red', 'white', 'purple'],

            _color;

        function Constructor(name, age, color) {
            parent.call(this, name, age);
            this.color = color;
        }

        Constructor.prototype = Object.create(parent.prototype);
        Constructor.prototype.toString = function () {
            var result = parent.prototype.toString.call(this);
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
    } (parent));

    module.exports = Cat;
} (require('./animal')()));

(function () {
    var Cat = require('./cat');
    var kittu = new Cat('name', 14, 'red');
    console.log(kittu.toString());
} ());