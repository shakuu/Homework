'use strict';

module.exports = function (app, superheroesData) {
  const express = require('express');
  const superheroController = require('../controllers/superhero-controller')(superheroesData);

  const superheroRouter = new express.Router();
  superheroRouter
    .get('/create', superheroController.createSuperheroForm)
    .post('/create', superheroController.createSuperhero)
    .get('/:superheroId', superheroController.details)
    .get('/', superheroController.index);


  app.use('/superheroes', superheroRouter);
};