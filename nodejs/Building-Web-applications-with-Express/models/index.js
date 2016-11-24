module.exports = function(){
  const Superhero = require('./superhero-model');
  const User = require('./user-model');

  return {
    Superhero,
    User
  };
};