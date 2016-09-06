'use strict';

let LinkedList = require('./task/task-1');
const values = 'babel src --presets es2015 --out-dir ./build -s -w'.split(' ');
let list = new LinkedList();
list.append(...values);
console.log(list.at(0));
// list.prepend(45).append(1, 2, 3).prepend(4, 5).insert(0, 500);

// console.log(list.toString());
// console.log(list.at(0));
// console.log(list.removeAt(0));
// console.log(list.toString());