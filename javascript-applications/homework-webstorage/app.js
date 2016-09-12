const game = require('./tasks/task-1')();


const ramsSheep = Object.create(game).init();
ramsSheep.guess(1234);
console.log(ramsSheep);