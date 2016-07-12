function solve(args) {
    var str = (args[0] + '').toLowerCase(),
        key = +args[1],
        output = '',
        sum = 0,
        product = 1;

    function appendChar(prevChr, counter) {
        if (+counter === 1) {
            output += prevChr;
        } else if (+counter === 2) {
            output += prevChr + prevChr;
        } else {
            output += counter + '' + prevChr;
        }
    }

    function compress() {
        var counter = 1,
            prevChr = str[0];

        for (var i = 1; i < str.length; i += 1) {

            if (str[i] === prevChr) {
                counter += 1;
            } else {
                appendChar(prevChr, counter);
                counter = 1;
            }

            prevChr = str[i];
        }

        appendChar(prevChr, counter);

        return output;
    }

    function encrypt(chr) {
        if (+chr) {
            return chr;
        } else {
            var chrCode = (chr + '').charCodeAt(0) - key;

            while (chrCode < 97) {
                chrCode += 26;
            }

            return chrCode ^ (chr + '').charCodeAt(0);
        }
    }

    str = compress();
    output = '';

    for (var i = 0; i < str.length; i += 1) {
        output += encrypt(str[i]);
    }

    str = output;

    for (var i = 0; i < str.length; i += 1) {
        if (+str[i] % 2) {
            product *= +str[i];
        } else {
            sum += +str[i];
        }
    }

    console.log(sum);
    console.log(product);
}

module.exports = {
    solve
};
