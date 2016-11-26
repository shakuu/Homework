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

  function allWithPagination(page, size) {
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

  return {
    createFraction,
    findById,
    allWithPagination
  };
};