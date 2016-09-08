const result = require('./tasks/solution')();

const cat = result.getBookCatalog('asdf', []);

cat.add(1, 2, 3);
cat.add([1, 2, 3]);