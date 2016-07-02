const task1 = require('./01-max-sum.js');
const task2 = require('./02-labyrinth.js');
const task3 = require('./03-listy.js');

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

// task2.solve(task2_test3);

const task3_test1 = [
    'def func sum[5, 3, 7, 2, 6, 3]',
    'def func2 [5, 3, 7, 2, 6, 3]',
    'def func3 min[func2]',
    'def func4 max[5, 3, 7, 2, 6, 3]',
    'def func5 avg[5, 3, 7, 2, 6, 3]',
    'def func6 sum[func2, func3, func4 ]',
    'sum[func6, func4]'
];

const task3_test2 = [
    'def func sum[1, 2, 3, -6]',
    'def newList [func, 10, 1]',
    'def newFunc sum[func, 100, newList]',
    '[newFunc]'
];

task3.solve(task3_test2);