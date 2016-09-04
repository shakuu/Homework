const result = require('./tasks/solution')();

let cat = result.getBookCatalog('asdfgs');
let res = cat.search('asd');

console.log(res);