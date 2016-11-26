'use strict';

module.exports = function (app, superheroesData) {
  const express = require('express');
  const superheroController = require('../controllers/superhero-controller')(superheroesData);

  const superheroRouter = new express.Router();
  superheroRouter
    .get('/:superheroId', superheroController.details)
    .get('/', superheroController.index)
    .post('/', superheroController.createSuperhero);    

  app.use('/superheroes', superheroRouter);
};