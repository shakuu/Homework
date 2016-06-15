String.prototype.bind = function (binding, data) {
  // Assuming a single tag
  var str = String(binding);
  var toInsert = data;

  var matchDataBind = new RegExp('data-bind-(([a-z]*)="([a-z]*)")', 'g');
  var allDataBinds = str.match(matchDataBind);

  var innerMatching = new RegExp('data-bind-(([a-z]*)="([a-z]*)")');
  var len = allDataBinds.length;
  for (let i = 0; i < len; i += 1) {
    var current = String(allDataBinds[i]);

    var result = current.match(innerMatching);
    var index = str.indexOf('>');
    var insert = toInsert[result[3]];

    if (String(result[2]) === 'content') {
      str = str.slice(0, index + 1) + insert + str.slice(index + 1);
    } else {
      var replaced = String(result[1]).replace(result[3], insert);
      str = str.slice(0, index) + ' ' + replaced + str.slice(index);
    }
  }

  return str;
};

var str = '<div data-bind-content="name"></div>';
var binding = {name: 'Steven'};
str = str.bind(str, {name: 'Steven'});
console.log(str);

var bindingString = '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"></а>';
console.log(bindingString.bind(bindingString, { name: 'Elena', link: 'http://telerikacademy.com' })); 