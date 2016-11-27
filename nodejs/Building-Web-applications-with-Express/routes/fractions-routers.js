'use strict';

module.exports = function (app, fractionsData, userData) {
  const express = require('express');
  const fractionsConroller = require('../controllers/fractions-controller')(fractionsData, userData);

  const fractionsRouter = new express.Router();
  fractionsRouter
    .get('/add/:fractionId', fractionsConroller.addFractionToFavorites)
    .get('/:fractionId', fractionsConroller.details)
    .get('/', fractionsConroller.index)
    .post('/', fractionsConroller.createFraction)
    .get('*', (req, res) => res.redirect('/fractions'));

  app.use('/fractions', fractionsRouter);
};