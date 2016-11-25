'use strict';

module.exports = function (app, superheroData) {
  const express = require('express');
  const superheroController = require('../controllers/superhero-controller')(superheroData);

  const superheroRouter = new express.Router();

  app.use('/superheroes', superheroRouter);
};