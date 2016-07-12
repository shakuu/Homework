function solve(args) {

  String.prototype.format = function (s) {
    var matchPlaceholders = new RegExp('#\{[a-z]*\}', 'g');
    var matchFields = new RegExp('[a-z]+');

    var matches = this.match(matchPlaceholders);
    var len = matches.length;

    for (let index = 0; index < len; index += 1) {
      var replaceWith = String(matches[index]).match(matchFields);
      console.log(options[replaceWith[0]]);
      str = str.replace(matches[index], options[replaceWith[0]]);
    }

    console.log(str);
  };

  var str = args[1];
  var options = args[0];

  str.format(options);
}

// const test1 = [
//   '{ "name": "John" }',
//   "Hello, there! Are you #{name}?"
// ];

// solve(test1);

module.exports = {
  solve
};