const task2 = require('./02-chess-moves.js');
const task3 = require('./03-cookie-styles.js');

const task2_test1 = [
    '3',
    '4',
    '--R-',
    'B--B',
    'Q--Q',
    '12',
    'd1 b3',
    'a1 a3',
    'c3 b2',
    'a1 c1',
    'a1 b2',
    'a1 c3',
    'a2 b3',
    'd2 c1',
    'b1 b2',
    'c3 b1',
    'a2 a3',
    'd1 d3'
];

// task2.solve(task2_test1);

const task3_test1 = [
    '#the-big-b{',
    '  color: yellow;',
    '  size: big;',
    '}',
    '.muppet{',
    '  powers: all;',
    '  skin: fluffy;',
    '}',
    '     .water-spirit         {',
    '  powers: water;',
    '             alignment    : not-good;',
    '\t\t\t\t}',
    'all{',
    '  meant-for: nerdy-children;',
    '}',
    '.muppet      {',
    '\tpowers: everything;',
    '}',
    'all              .muppet {',
    '\talignment             :             good                             ;',
    '}',
    '   .muppet+             .water-spirit{',
    '   power: everything-a-muppet-can-do-and-water;',
    '}'
];

task3.solve(task3_test1);