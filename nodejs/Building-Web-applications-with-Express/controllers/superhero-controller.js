'use strict';

module.exports = function (superheroData) {
  function createSuperhero(req, res) {
    superheroData.createSuperhero(req.body)
      .then(() => {
        res.status(201);
      })
      .catch((err) => {
        res.status(400);
      });
  }

  function createSuperheroForm(req, res) {
    if (!req.isAuthenticated()) {
      return res.redirect('/account/login');
    }

    return res.render('/superheroes/create');
  }

  return {
    createSuperhero,
    createSuperheroForm
  };
};