const task1 = require('./01-sequence.js');
const task2 = require('./02-joro.js');
const task3 = require('./03-clojure.js');

const task1_test1 = ['7', '1', '2', '-3', '4', '4', '0', '1'];
const task1_test2 = ['6', '1', '3', '-5', '8', '7', '-6'];
const task1_task3 = ['9', '1', '8', '8', '7', '6', '5', '7', '7', '6'];

// task1.solve(task1_test1);

const task2_test1 = ['6 7 3', '0 0', '2 2', '-2 2', '3 -1'];

// task2.solve(task2_test1);

const task3_test1 = [
    '(def func 10)',
    '(def newFunc (+  func 2))',
    '(def sumFunc (+ func func newFunc 0 0 0))',
    '(* sumFunc 2)'
];

const task3_test2 = [
    '(def func (+ 5 2))',
    '(def func2 (/  func 5 2 1 0))',
    '(def func3 (/ func 2))',
    '(+ func3 func)'
];

task3.solve(task3_test1);


