function solve(args) {
    var str = (args[0] + '').toLowerCase(),
        key = +args[1],
        sum = 0,
        product = 1;

    var CONSTANTS = {
        ALPHABET: 'abcdefghijklmnopqrstuvwxyz'
    }

    function appendChar(prevChr, counter) {
        if (+counter === 1) {
            return prevChr;
        } else if (+counter === 2) {
            return prevChr + prevChr;
        } else {
            return counter + '' + prevChr;
        }
    }

    function compress() {
        var counter = 1,
            output = '',
            prevChr = str[0];

        for (var i = 1; i < str.length; i += 1) {

            if (str[i] === prevChr) {
                counter += 1;
            } else {
                output += appendChar(prevChr, counter);
                counter = 1;
            }

            prevChr = str[i];
        }

        output += appendChar(prevChr, counter);

        return output;
    }

    function getShiftedCode(chr) {
        var code = (chr + '').charCodeAt(0) - key;

        while (code < 97) {
            code += CONSTANTS.ALPHABET.length;
        }

        return code;
    }

    function encrypt() {
        var output = '';

        for (var i = 0; i < str.length; i += 1) {

            if (+str[i]) {
                output += str[i];
            } else {
                var shiftedCode = getShiftedCode(str[i]);
                output += shiftedCode ^ str[i].charCodeAt(0);
            }
        }

        return output;
    }

    function output() {

        for (var i = 0; i < str.length; i += 1) {
            if (+str[i] % 2) {
                product *= +str[i];
            } else {
                sum += +str[i];
            }
        }
    }

    str = compress();
    str = encrypt();
    output();

    console.log(sum);
    console.log(product);
}

module.exports = {
    solve
};