'use strict';

module.exports = function (app, superheroesData, fractionsData, userData) {
  const express = require('express');
  const superheroController = require('../controllers/superhero-controller')(superheroesData, fractionsData, userData);

  const superheroRouter = new express.Router();
  superheroRouter
    .get('/add/:superheroId', superheroController.addSuperheroToFavorites)
    .get('/:superheroId/removepower/:powerName', superheroController.removePowerFromSuperhero)
    .get('/:superheroId', superheroController.details)
    .get('/', superheroController.index)
    .post('/', superheroController.createSuperhero)
    .post('/addpower/:superheroId', superheroController.addPowerToSuperhero);

  app.use('/superheroes', superheroRouter);
};