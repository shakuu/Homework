'use strict';

module.exports = function (superheroesData) {
  function createSuperhero(req, res) {
    superheroesData.create(req.body)
      .then(() => {
        res.redirect('/');
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