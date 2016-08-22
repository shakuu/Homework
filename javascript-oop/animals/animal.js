function Animal() {
    var Animal = (function () {
        var _name,
            _age;

        function Constructor(name, age) {
            _name = name;
            _age = age;
        }

        Constructor.prototype.toString = function () {
            return _name + ' ' + _age;
        };

        return Constructor;
    } ());
    return Animal;
}
module.exports = Animal;