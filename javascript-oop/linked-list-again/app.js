'use strict';

let LinkedList = require('./task/task-1');

let list = new LinkedList();
list.prepend(45).append(1, 2, 3).prepend(4, 5).insert(0, 500);

console.log(list.toString());
console.log(list.at(6));
console.log(list.removeAt(0));
console.log(list.toString());