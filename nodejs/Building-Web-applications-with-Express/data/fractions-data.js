/* globals Promise */

'use strict';

module.exports = function (Fraction) {
  function createFraction(fraction) {
    return new Promise((resolve, reject) => {
      const newFraction = Fraction.getFraction(fraction);

      newFraction.save((err) => {
        if (err) {
          return reject(err);
        }

        return resolve(newFraction);
      });
    });
  }

  function findByName(name) {
    return new Promise((resolve, reject) => {
      Fraction.findOne({
        name
      }, (err, fraction) => {
        if (err) {
          return reject(err);
        }

        return resolve(fraction);
      });
    });
  }

  function findById(id) {
    return new Promise((resolve, reject) => {
      Fraction.findOne({
        _id: id
      }, (err, fraction) => {
        if (err) {
          return reject(err);
        }

        return resolve(fraction);
      });
    });
  }

  function allWithPagination(page = 0, size = 5) {
    return new Promise((resolve, reject) => {
      Fraction
        .find()
        .skip(page * size)
        .limit(size)
        .exec((err, fractions) => {
          if (err) {
            return reject(err);
          }

          return resolve(fractions);
        });
    });
  }

  function updateFractionPlanets(fraction) {
    return new Promise((resolve, reject) => {
      fraction.save((err) => {
        if (err) {
          return reject(err);
        }

        return resolve(fraction);
      });

      // Fraction.update({
      //   _id: fraction._id
      // }, {
      //   $set: {
      //     planets: fraction.planets
      //   }
      // }, (err, updatedFraction) => {
      //   if (err) {
      //     return reject(err);
      //   }

      //   return resolve(updatedFraction);
      // });
    });
  }

  return {
    createFraction,
    findByName,
    findById,
    allWithPagination,
    updateFractionPlanets
  };
};