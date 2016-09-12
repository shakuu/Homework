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

    const StorageProviderMixin = (() => {
        const STORAGE_ITEM = 'SHEEP_AND_RAMS_SCORE_LIST';
        const messages = [];

        // Add localStorage
        return Base => class extends Base {
            constructor(args) {
                super(args);
            }

            saveMessage(message) {
                messages.push(message);
            }

            loadAllMessages() {
                return messages;
            }
        };
    })();

    const SheepAndRamsGame = (() => {
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

                        let isUnique = validator.validateUniqueDigit(number[index], number);
                        while (!isUnique && index !== 0) {
                            number[index] = _.random(0, 9);
                            isUnique = validator.validateUniqueDigit(number[index], number);
                        }
                    });

                    const randomNumber = Number(result.join(''));
                    return randomNumber;
                }
            };
        })();

        class GameLogic extends StorageProviderMixin(Object) {
            constructor(playerName, endCallback) {
                super();

                this.isRunning = true;
                this.playerName = playerName;
                this.endCallback = endCallback;

                this._scoreList = [];
                this._guessesCount = 0;
                this.__secretNumber__ = secretNumberGenerator.generateSecretNumber(4);
            }

            evaluateGuess(number) {
                if (!this.isRunning) {
                    throw new Error('Run init()');
                }

                validator.validateGuess(number);

                this._guessesCount += 1;
                const rams = game._countRams(number);
                const sheep = game._countSheep(number);

                if (rams === 4) {
                    this.isRunning = false;
                    this._updateScore(this.playerName, this._guessesCount);
                    this.endCallback();
                }

                return { rams, sheep };
            }

            getHighScore(count) {
                const allMessages = this.loadAllMessages();
                const result = _.chain(allMessages)
                    .map(msg => JSON.parse(msg))
                    .sortBy(msg => msg.score)
                    .reverse()
                    .take(count)
                    .value();

                return result;
            }

            _updateScore(playerName, guessesCount) {
                const message = JSON.stringify({
                    name: playerName,
                    score: guessesCount
                });

                this.saveMessage(message);
            }

            _countRams(guess) {
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

            _countSheep(guess) {
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
        game = new SheepAndRamsGame(playerName, endCallback);
    }

    function guess(number) {
        if (!game || !game.isRunning) {
            throw new Error('Invoke init().');
        }

        const outcome = game.evaluateGuess(number);
        return outcome;
    }

    function getHighScore(count) {
        const highScoreList = game.getHighScore(count);
        return highScoreList;
    }

    return {
        init,
        guess,
        getHighScore
    };
}


module.exports = solve;
