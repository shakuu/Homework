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

  return {
    createSuperhero
  };
};