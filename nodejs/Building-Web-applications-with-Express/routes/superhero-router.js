'use strict';

module.exports = function (app, superheroData) {
  const express = require('express');
  const superheroController = require('../controllers/superhero-controller')(superheroData);

  const superheroRouter = new express.Router();
  superheroRouter
    .get('/create', superheroController.createSuperheroForm)
    .post('/create', superheroController.createSuperhero);

  app.use('/superheroes', superheroRouter);
};