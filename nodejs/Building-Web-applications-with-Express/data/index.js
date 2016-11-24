const mongoose = require('mongoose');

module.exports = function (config, models) {
  mongoose.Promise = global.Promise;
  
  mongoose.connect(config.connectionString, (err) => {
    if (err) {
      console.log(err.message);
    }
  });

  const superheroesData = require('./superheroes-data')(models.Superhero);
  const userData = require('./users-data')(models.User);

  return {
    superheroesData,
    userData
  };
};