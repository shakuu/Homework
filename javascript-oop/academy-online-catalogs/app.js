const result = require('./tasks/solution')();

let cat = result.getMediaCatalog('asdfgs');
let res = cat.find();

console.log(res);