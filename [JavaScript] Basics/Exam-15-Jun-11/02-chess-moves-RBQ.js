function solve(params) {
    var rows = parseInt(params[0]),
        cols = parseInt(params[1]),
        tests = parseInt(params[rows + 2]), i, move;
    
    var alphabet = 'abcdefghijklmnopqrstuvwxyz';

    for (i = 0; i < tests; i++) {
        move = params[rows + 3 + i];
        // Your solution here
        console.log('yes'); // or console.log('no');
    }
}