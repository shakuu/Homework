const mod = require('./tasks/task-1')();

const p = mod.getPlayer("Name");
console.log(p.name);