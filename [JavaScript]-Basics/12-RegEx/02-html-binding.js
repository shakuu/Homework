function solve(args) {
    'use strict';

    String.prototype.bind = function (data) {
        // Assuming a single tag
        var str = String(this);
        var toInsert = data;

        var matchDataBind = new RegExp('data-bind-(([a-z]*)="([a-z|S]*)")', 'gmi');
        var allDataBinds = str.match(matchDataBind);

        var innerMatching = new RegExp('data-bind-(([a-z]*)="([a-z|S]*)")');
        var len = allDataBinds.length;

        for (let i = 0; i < len; i += 1) {
            var current = String(allDataBinds[i]);

            var result = current.match(innerMatching);
            var index = str.indexOf('>');


            var insert = toInsert[result[3]];

            if (String(result[2]) === 'content') {
                str = str.slice(0, index + 1) + insert + str.slice(index + 1);
            } else {

                if (str[index - 1] === '/') {
                    index -= 1;
                }

                var replaced = String(result[1]).replace(result[3], insert);
                str = str.slice(0, index) + ' ' + replaced + str.slice(index);
            }
        }

        return str;
    };

    var data = JSON.parse(args[0]);
    var str = (args[1] + '').replace(/\s\s+/g, ' ');

    console.log(str.bind(data));
}

module.exports = {
    solve
};
