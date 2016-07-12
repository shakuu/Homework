function solve(args) {
    // fix
    let input = args.slice();
    let extractedProperties = [];

    // Get object
    input[0].split(',')
        .map(String)
        .map(str => {
            // let matchProps = /"([\w|\d|\s|.]*)":"?([\w|\d|\s|.]*)"?/i;
            let matchProps = /"([\w|\d|\s|.]*)":/g;
            let matchValues = /:(.*)/i;
            
            let result = str.match(matchProps);
            let vals = str.match(matchValues);
            if (result !== null) {
                extractedProperties[result[1]] = (result[2]);
            }
            return str;
        });

    let matchOptions = /#{(.*?)}/;
    let res = input[1].match(matchOptions);

    while (res) {
        input[1] = input[1].replace(res[0], extractedProperties[res[1]].trim('"'));
        res = input[1].match(matchOptions);
    }

    console.log(input[1]);
}

const test1 = [
    '{"name":"John","age":13}',
    'My name is #{name} and I am #{age}-years-old'
];

solve(test1);