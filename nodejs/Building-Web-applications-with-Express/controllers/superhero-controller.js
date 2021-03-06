/* globals Promise */

'use strict';

module.exports = function (superheroesData, fractionsData, userData, planetsData) {
  function index(req, res) {
    const page = +req.query.page || 0;
    const size = +req.query.size || 3;

    superheroesData.allWithPagination(page, size)
      .then(([superheroes, pageCount]) => {
        if (pageCount < page) {
          return res.redirect(`/superheroes?page=${pageCount - 1}&size=${size}`);
        }

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
        return res.render('./superheroes/index', {
          result: {
            superheroes,
            isAuthenticated,
            pagination
          }
        });
      })
      .catch((err) => {
        res.send(err.message);
      });
  }

  function createSuperhero(req, res) {
    if (!req.isAuthenticated()) {
      return res.redirect('/account/login');
    }

    const superhero = req.body;

    if (superhero.powers) {
      const powers = superhero.powers.split(/[,]+/).map(p => p.trim());
      superhero.powers = powers;
    }

    if (superhero.fractions) {
      const fractions = superhero.fractions.split(/[,]+/).map(f => f.trim());
      superhero.fractions = fractions;
    }

    return superheroesData.createSuperhero(superhero)
      .then((createdSuperhero) => {
        return Promise.all([
          new Promise(resolve => resolve(createdSuperhero)),
          planetsData.findByName(createdSuperhero.planet)
        ]);
      })
      .then(([createdSuperhero, planet]) => {
        if (planet) {
          return [createdSuperhero];
        }

        const newPlanet = {
          name: createdSuperhero.planet,
          countries: [{
            name: createdSuperhero.country,
            cities: [createdSuperhero.city]
          }]
        };

        return Promise.all([
          new Promise(resolve => resolve(createdSuperhero)),
          planetsData.createPlanet(newPlanet)
        ]);
      })
      .then(([createdSuperhero]) => {
        if (createdSuperhero.fractions && createdSuperhero.fractions.length > 0) {
          return Promise.all([
            new Promise(resolve => resolve(createdSuperhero)),
            ...createdSuperhero.fractions.map(fractionName => {
              return fractionsData.findByName(fractionName);
            })
          ]);
        }

        return res.redirect('/superheroes');
      })
      .then(([createdSuperhero, ...fractions]) => {
        const planetName = createdSuperhero.planet;

        return Promise.all(
          fractions.map((fraction, i) => {
            if (fraction) {
              const exists = fraction.planets.some(p => p === planetName);
              if (!exists) {
                fraction.planets.push(planetName);
                return fractionsData.updateFractionPlanets(fraction);
              }

              return Promise.resolve();
            }

            return fractionsData.createFraction({
              name: createdSuperhero.fractions[i],
              alignment: createdSuperhero.alignment,
              planets: [planetName]
            });
          })
        );
      })
      .then(() => {
        res.redirect('/superheroes');
      })
      .catch((err) => {
        res.send(err.message);
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

  function addSuperheroToFavorites(req, res) {
    if (!req.isAuthenticated()) {
      return res.redirect('/account/login');
    }

    const exists = req.user.favoriteHeroes.some(s => s._id === req.params.superheroId);
    if (exists) {
      return res.redirect('/account');
    }

    return superheroesData.findById(req.params.superheroId)
      .then((superhero) => {
        req.user.favoriteHeroes.push({
          name: superhero.name,
          _id: superhero._id
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

  function addPowerToSuperhero(req, res) {
    if (!req.isAuthenticated()) {
      return res.redirect('/account/login');
    }

    const newPowerName = req.body.power;
    const superheroId = req.params.superheroId;

    if (!newPowerName) {
      return res.redirect(`/superheroes/${superheroId}`);
    }

    return superheroesData.findById(superheroId)
      .then((superhero) => {
        const powerExists = superhero.powers.forEach(p => p === newPowerName);
        if (powerExists) {
          return res.redirect(`/superheroes/${superheroId}`);
        }

        superhero.powers.push(newPowerName);
        return superheroesData.updateSuperhero(superhero);
      })
      .then(() => {
        return res.redirect(`/superheroes/${superheroId}`);
      })
      .catch((err) => {
        res.send(err);
      });
  }

  function removePowerFromSuperhero(req, res) {
    if (!req.isAuthenticated()) {
      return res.redirect('/account/login');
    }

    const powerName = req.params.powerName;
    const superheroId = req.params.superheroId;

    return superheroesData.findById(superheroId)
      .then((superhero) => {
        const powerExists = superhero.powers.some(p => p === powerName);
        if (!powerExists) {
          return res.redirect(`/superheroes/${superheroId}`);
        }

        superhero.powers = superhero.powers.filter(p => p !== powerName);
        return superheroesData.updateSuperhero(superhero);
      })
      .then(() => {
        return res.redirect(`/superheroes/${superheroId}`);
      })
      .catch((err) => {
        res.send(err.message);
      });
  }

  return {
    index,
    createSuperhero,
    addSuperheroToFavorites,
    details,
    addPowerToSuperhero,
    removePowerFromSuperhero
  };
};