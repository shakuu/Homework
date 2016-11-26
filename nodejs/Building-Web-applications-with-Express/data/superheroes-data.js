/* globals Promise module */

module.exports = function (Superhero) {
  function createSuperhero(options) {
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

  function findById(id) {
    return new Promise((resolve, reject) => {
      Superhero.findOne({
        _id: id
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

  function allWithPagination(pageNumber = 0, pageSize = 5) {
    return new Promise((resolve, reject) => {
      Superhero.find()
        .skip(pageNumber * pageSize)
        .limit(pageSize)
        .exec((err, superheroes) => {
          if (err) {
            return reject(err);
          }

          return resolve(superheroes);
        });
    });
  }

  return {
    createSuperhero,
    findByName,
    findById,
    all,
    allWithPagination
  };
};