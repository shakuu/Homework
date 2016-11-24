const mongoose = require('mongoose');

module.exports = function (config, models) {
  mongoose.connect(config.connectionString);
  mongoose.Promise = global.Promise;

  const superheroesData = require('./superheroes-data')(models.Superhero);
  const userData = require('./users-data');

  return {
    superheroesData,
    userData
  };
};