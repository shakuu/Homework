/* globals Promise module */
'use strict';

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
    const getPage = new Promise((resolve, reject) => {
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

    const getCount = new Promise((resolve, reject) => {
      Superhero.count((err, size) => {
        if (err) {
          return reject(err);
        }

        const pageCount = Math.ceil(size / pageSize);
        return resolve(pageCount);
      });
    });

    return Promise.all([
      getPage,
      getCount
    ]);
  }

  return {
    createSuperhero,
    findByName,
    findById,
    all,
    allWithPagination
  };
};