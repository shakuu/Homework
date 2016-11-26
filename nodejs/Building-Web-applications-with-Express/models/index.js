module.exports = function () {
  const Superhero = require('./superhero-model');
  const Fraction = require('./fractions-model');
  const User = require('./user-model');

  return {
    Superhero,
    Fraction,
    User
  };
};