'use strict';

module.exports = function (superheroesData) {
  function index(req, res) {
    const pageNumber = +req.query.page || 0;
    const pageSize = +req.query.size || 5;

    superheroesData.allWithPagination(pageNumber, pageSize)
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
    superheroesData.createSuperhero(req.body)
      .then(() => {
        res.redirect('/superheroes');
      })
      .catch((err) => {
        res.send(err);
      });
  }

  function createSuperheroForm(req, res) {
    if (!req.isAuthenticated()) {
      return res.redirect('/account/login');
    }

    return res.render('./superheroes/create');
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
    createSuperheroForm,
    details
  };
};