'use strict';

module.exports = function (superheroesData) {
  function index(req, res) {

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