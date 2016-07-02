var formatPlaceholders = require('./01-format-place.js');
var task2 = require('./02-html-binding-again.js');

const test1 = [
    '{ "name": "John" }',
    "Hello, there! Are you #{name}?"
];

// formatPlaceholders.solve(test1);



var task2_test1 = [
  '{ "name": "Steven" }',
  '<div data-bind-content="name"/></div>'
];

var task2_test2 = [
  '{ "name": "Elena", "link": "http://telerikacademy.com" }',
  '<a data-bind-content="name" data-bind-href="link" data-bind-class="name"/></а>'
];

task2.solve(task2_test2);