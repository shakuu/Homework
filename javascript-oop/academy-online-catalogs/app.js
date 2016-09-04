const result = require('./tasks/solution')();

var book = result.getMedia('asdf', 2, 2, 'dexc');
console.log(book);