/* globals Promise module */

module.exports = function (Superhero) {
  function create(options) {
    const superhero = Superhero.getSuperhero(options);
    return new Promise((resolve, reject) => {
      superhero.save((err) => {
        if (err) {
          return reject(err);
        }

        return resolve(superhero);
      });
    });
  }

  function findByName(name) {
    return new Promise((resolve, reject) => {
      Superhero.findOne({
        name
      }, (err, superhero) => {
        if (err) {
          return reject(err);
        }

        return resolve(superhero);
      });
    });
  }

  function all() {
    return new Promise((resolve, reject) => {
      Superhero.find((err, superheroes) => {
        if (err) {
          return reject(err);
        }

        return resolve(superheroes);
      });
    });
  }

  return {
    create,
    findByName,
    all
  };
};