const task1 = require('./01-max-sum.js');
const task2 = require('./02-labyrinth.js');

const task1_test1 = [
    '8',
    '1',
    '6',
    '-9',
    '4',
    '4',
    '-2',
    '10',
    '-1'
];

const task1_test2 = ['6', '1', '3', '-5', '8', '7', '-6'];
const task1_test3 = ['9', '-9', '-8', '-8', '-7', '-6', '-5', '-1', '-7', '-6'];

// task1.solve(task1_test3);

const task2_test1 = ['3 4', '1 3', 'lrrd', 'dlll', 'rddd'];
const task2_test2 = [
    '5 8',
    '0 0',
    'rrrrrrrd',
    'rludulrd',
    'durlddud',
    'urrrldud',
    'ulllllll'
];

const task2_test3 = [
    '5 8',
    '0 0',
    'rrrrrrrd',
    'rludulrd',
    'lurlddud',
    'urrrldud',
    'ulllllll'
];

task2.solve(task2_test3);