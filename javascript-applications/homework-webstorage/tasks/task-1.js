const _ = require('underscore');

function solve() {
    'use strict()';

    const numberGenerator = (() => {
        return {
            generateRandomNumber(length) {
                length = length || 4;

                let result = _.range(length);
                result = _.map(result, el => el = _.random(0, 9));

                result.forEach((digit, index, number) => {
                    while (digit === 0 && index === 0) {
                        number[index] = _.random(1, 9);
                    }

                    let isUnique = validator.validateUniqueDigit(digit, number);
                    while (!isUnique && index !== 0) {
                        number[index] = _.random(0, 9);
                        isUnique = validator.validateUniqueDigit(digit, number);
                    }
                });

                const randomNumber = Number(result.join(''));
                return randomNumber;
            }
        };
    })();

    const validator = (() => {
        const DIGITS_DICTIONARY = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];

        return {
            validateGuess(number) {
                if (isNaN(number)) {
                    throw new Error('Guess must be a number.');
                }

                const digits = number.toString().split('').map(Number);
                for (const digit of DIGITS_DICTIONARY) {
                    const isUnique = validator.validateUniqueDigit(digit, digits);
                    if (!isUnique) {
                        throw new Error('Guess must contain unique digits.');
                    }
                }
            },
            validateUniqueDigit(digit, digits) {
                const query = _.countBy(digits, d => d === digit);
                query.true = query.true || 0;
                return query.true <= 1;
            }
        };
    })();

    function init(playerName, endCallback) {
        this.playerName = playerName;
        this.secretNumber = numberGenerator.generateRandomNumber(4);
        this.isRunning = true;
        return this;
    }

    function guess(number) {
        if (!this.isRunning) {
            throw new Erro('Invoke init().');
        }

        validator.validateGuess(number);
        const result = {
            sheep: null,
            rams: null
        };

        return result;
    }

    function getHighScore(count) {

    }

    return {
        init,
        guess,
        getHighScore
    };
}


module.exports = solve;
