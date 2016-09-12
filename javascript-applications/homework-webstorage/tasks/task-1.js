const _ = require('underscore');

function solve() {
    'use strict()';

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

    const GameLogic = (() => {
        function convertToArray(number) {
            const convertedNumber = number.toString().split('').map(Number);
            return convertedNumber;
        }

        const secretNumberGenerator = (() => {
            return {
                generateSecretNumber(length) {
                    length = length || 4;

                    let result = _.range(length);
                    result = _.map(result, el => el = _.random(0, 9));
                    result.forEach((digit, index, number) => {
                        while (index === 0 && digit === 0) {
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

        class GameLogic {
            constructor(playerName, endCallback) {
                this.playerName = playerName;
                this.endCallback = endCallback;
                this.isRunning = true;

                this._scoreList = [];
                this.__secretNumber__ = secretNumberGenerator.generateSecretNumber(4);
            }

            countRams(guess) {
                const convertedGuess = convertToArray(guess);
                const convertedSecretNumber = convertToArray(this.__secretNumber__);

                let count = 0;
                for (let i = 0; i < convertedSecretNumber.length; i += 1) {
                    if (convertedGuess[i] === convertedSecretNumber[i]) {
                        count += 1;
                    }
                }

                return count;
            }

            countSheep(guess) {
                const convertedGuess = convertToArray(guess);
                const convertedSecretNumber = convertToArray(this.__secretNumber__);

                let sheepCount = 0;
                for (let guessIndex = 0; guessIndex < convertedGuess.length; guessIndex += 1) {
                    const guessDigit = convertedGuess[guessIndex];
                    for (let secretIndex = 0; secretIndex <= convertedSecretNumber.length; secretIndex += 1) {
                        const secretDigit = convertedSecretNumber[secretIndex];
                        if (guessIndex !== secretIndex && guessDigit === secretDigit) {
                            sheepCount += 1;
                            break;
                        }
                    }
                }

                return sheepCount;
            }
        }

        return GameLogic;
    })();

    let game;

    function init(playerName, endCallback) {
        game = new GameLogic(playerName, endCallback);
        return game;
    }

    function guess(number) {
        if (!game.isRunning) {
            throw new Error('Invoke init().');
        }

        validator.validateGuess(number);

        const outcome = {
            rams: game.countRams(number),
            sheep: game.countSheep(number)
        };

        // if (outcome.rams === 4) {
        //     gameLogic.handleWin();
        //     this.onWinCallback();
        // }

        return outcome;
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
