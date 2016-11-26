'use strict';

module.exports = function (fractionsData, userData) {
  function index(req, res) {
    const page = +req.query.page || 0;
    const size = +req.query.size || 3;

    fractionsData.allWithPagination(page, size)
      .then(([fractions, pageCount]) => {
        const pagination = {
          active: +pageCount > 1,
          pageSize: size,
          previous: {
            active: +page > 0,
            value: +page - 1
          },
          next: {
            active: +page < +pageCount - 1,
            value: +page + 1
          }
        };

        const isAuthenticated = req.isAuthenticated();
        res.render('./fractions/index', {
          result: {
            fractions,
            isAuthenticated,
            pagination
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

  function addFractionToFavorites(req, res) {
    if (!req.isAuthenticated()) {
      return res.redirect('/account/login');
    }

    const exists = req.user.favoriteFractions.some(f => f._id === req.params.fractionId);
    if (exists) {
      return res.redirect('/account');
    }

    return fractionsData.findById(req.params.fractionId)
      .then((fraction) => {
        req.user.favoriteFractions.push({
          name: fraction.name,
          _id: fraction._id
        });

        return userData.updateUser(req.user);
      })
      .then(() => {
        res.redirect('/account');
      })
      .catch((err) => {
        res.send(err);
      });
  }

  return {
    index,
    createFraction,
    addFractionToFavorites
  };
};