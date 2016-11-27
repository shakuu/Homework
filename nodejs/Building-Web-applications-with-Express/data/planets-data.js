/* globals Promise */

'use strict';

module.exports = function (Planet) {
  function createPlanet(planet) {
    return new Promise((resolve, reject) => {
      const newPlanet = Planet.getPlanet(planet);

      newPlanet.save((err) => {
        if (err) {
          return reject(err);
        }

        return resolve(newPlanet);
      });
    });
  }

  function allWithPagination(page, size) {
    return new Promise((resolve, reject) => {
      Planet.find()
        .skip(page * size)
        .limit(size)
        .exec((err, planets) => {
          if (err) {
            return reject(err);
          }

          return resolve(planets);
        });
    });
  }

  return {
    createPlanet,
    allWithPagination
  };
};