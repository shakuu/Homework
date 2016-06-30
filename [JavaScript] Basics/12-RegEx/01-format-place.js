// function solve(args) {
//     var data = JSON.parse(args[0]),
//         result;

//     String.prototype.replacePlaceholders = function (data) {
//         var regex = /#\{(\w+)\}/g,
//             result = this.replace(regex, function (match) {
//                 matchX = match.slice(2, match.length - 1);
//                 console.log(data[matchX], match);
//                 console.log(data[matchX] || match);
//                 return data[matchX] || match;
//             });

//         return result;
//     };

//     result = args[1].replacePlaceholders(data);
//     console.log(result);
// }

function solve(args) {
    let data = JSON.parse(args[0]),
        result = '';

    let matchOptions = /#{([\w|\d|\S]+)}/i;
    result = args[1].match(matchOptions);
    
    while (result) {
        args[1] = args[1].replace(result[0], data[result[1]]);
        result = args[1].match(matchOptions);
    }

    console.log(args[1]);
}

const test1 = [
    '{"name":"John","age":""}',
    'My name is #{name} and I am #{age}-years-old'
];

solve(test1);