'use strict';

module.exports = function (superheroesData, fractionsData) {
  function index(req, res) {
    const page = +req.query.page || 0;
    const size = +req.query.size || 5;

    superheroesData.allWithPagination(page, size)
      .then((superheroes) => {
        const isAuthenticated = req.isAuthenticated();
        res.render('./superheroes/index', {
          result: {
            superheroes,
            isAuthenticated
          }
        });
      })
      .catch((err) => {
        res.send(err);
      });
  }

  function createSuperhero(req, res) {
    const superhero = req.body;
    if (superhero.powers) {
      const powers = superhero.powers.split(/[,]+/).map(p => p.trim());
      superhero.powers = powers;
    }

    if (superhero.fractions) {
      const fractions = superhero.fractions.split(/[,]+/).map(f => f.trim());
      superhero.fractions = fractions;
    }

    superheroesData.createSuperhero(superhero)
      .then((createdSuperhero) => {
        if (createdSuperhero.fractions && createdSuperhero.fractions.length > 0) {
          createdSuperhero.fractions.forEach(f => {
            return fractionsData.findByName(f)
              .then((fraction) => {
                if (fraction) {
                  fraction.planets.push(createdSuperhero.planet);
                  return fractionsData.updateFractionPlanets(fraction);
                }

                return fractionsData.createFraction({
                  name: f,
                  alignment: createdSuperhero.alignment
                });
              })
              .catch((err) => {
                console.log(err);
              });
          });
        }
      })
      .then(() => {
        res.redirect('/superheroes');
      })
      .catch((err) => {
        res.send(err);
      });
  }

  function details(req, res) {
    if (!req.isAuthenticated()) {
      return res.redirect('/account/login');
    }

    return superheroesData.findById(req.params.superheroId)
      .then((superhero) => {
        res.render('./superheroes/details', {
          result: superhero
        });
      })
      .catch((err) => {
        res.send(err);
      });
  }

  return {
    index,
    createSuperhero,
    details
  };
};