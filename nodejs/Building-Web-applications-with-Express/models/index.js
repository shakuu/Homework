module.exports = function () {
  const Superhero = require('./superhero-model');
  const Fraction = require('./fractions-model');
  const User = require('./user-model');
  const Planet = require('./planet-model');

  return {
    Superhero,
    Fraction,
    User,
    Planet
  };
};