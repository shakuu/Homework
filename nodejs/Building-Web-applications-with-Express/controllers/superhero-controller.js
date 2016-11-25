'use strict';

module.exports = function (superheroesData) {
  function index(req, res) {
    const pageNumber = req.query.page || 0;
    const pageSize = req.query.size || 5;

    superheroesData.allWithPagination(pageNumber, pageSize)
      .then((superheroes) => {
        res.render('./superheroes/index', {
          result: superheroes
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

  return {
    createSuperhero,
    createSuperheroForm
  };
};