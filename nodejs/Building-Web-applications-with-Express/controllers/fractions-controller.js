'use strict';

module.exports = function (fractionsData) {
  function index(req, res) {
    const page = +req.query.page || 0;
    const size = +req.query.size || 5;

    fractionsData.allWithPagination()
      .then((fractions) => {
        res.render('./fractions/index', {
          result: {
            fractions,
            isAuthenticated: req.isAuthenticated()
          }
        });
      })
      .catch((err) => {
        res.send(err);
      });
  }

  function createFraction(req, res) {
    const fraction = req.body;
    if (fraction.planets) {
      const planets = fraction.planets.split(/[,]+/).map(p => p.trim());
      fraction.planets = planets;
    }

    fractionsData.createFraction(fraction)
      .then((createdFraction) => {
        res.send(createdFraction);
      })
      .catch((err) => {
        res.send(err);
      });
  }

  return {
    index,
    createFraction
  };
};