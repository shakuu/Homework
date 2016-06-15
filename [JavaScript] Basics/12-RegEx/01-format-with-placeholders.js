String.prototype.format = function (args) {
  var str = String(this);
  var options = args;

  var matchPlaceholders = new RegExp('#\{[a-z]*\}', 'g');
  var matchFields = new RegExp('[a-z]+');

  var matches = this.match(matchPlaceholders);
  var len = matches.length;

  for (let index = 0; index < len; index += 1) {
    var replaceWith = String(matches[index]).match(matchFields);
    str = str.replace(matches[index], options[replaceWith]);
  }

  console.log(str);
};

var options = {name: 'John'};
'Hello, there! Are you #{name}?'.format(options);

var str = 'My name is #{blah} and I am #{blah}-years-old';
var options = { blah: 'az', age: '13' };

str.format(options);