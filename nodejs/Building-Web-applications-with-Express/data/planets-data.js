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

  function findByName(name) {
    return new Promise((resolve, reject) => {
      Planet.findOne({
        name
      }, (err, planet) => {
        if (err) {
          return reject(err);
        }

        return resolve(planet);
      });
    });
  }

  return {
    createPlanet,
    allWithPagination,
    findByName
  };
};