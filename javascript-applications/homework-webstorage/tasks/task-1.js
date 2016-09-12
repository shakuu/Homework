const _ = require('underscore');

function solve() {
    'use strict()';

    const numberGenerator = (() => {
        return {
            generateRandomNumber(length) {
                length = length || 4;

                let result = _.range(length);
                result = _.map(result, el => el = _.random(0, 9));

                result.forEach((el, index, arr) => {
                    while (el === 0 && index === 0) {
                        el = _.random(1, 9);
                    }

                    while (arr.indexOf(el) >= 0 && arr.indexOf(el) !== index && index !== 0) {
                        el = _.random(0, 9);
                    }
                });

                return Number(result.join(''));
            }
        };
    })();



    function init(playerName, endCallback) {
        this.playerName = playerName;
        this.secretNumber = numberGenerator.generateRandomNumber(4);
        return this;
    }

    function guess(number) {
        const result = {
            sheep: null,
            rams: null
        };

        return result;
    }

    function getHighScore(count) {

    }

    return {
        init, guess, getHighScore
    };
}


module.exports = solve;
