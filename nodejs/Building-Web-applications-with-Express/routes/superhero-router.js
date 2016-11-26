'use strict';

module.exports = function (app, superheroesData, fractionsData, userData) {
  const express = require('express');
  const superheroController = require('../controllers/superhero-controller')(superheroesData, fractionsData, userData);

  const superheroRouter = new express.Router();
  superheroRouter
    .get('/add/:superheroId', superheroController.addSuperheroToFavorites)
    .get('/:superheroId', superheroController.details)
    .get('/', superheroController.index)
    .post('/', superheroController.createSuperhero);

  app.use('/superheroes', superheroRouter);
};