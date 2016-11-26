'use strict';

module.exports = function (app, fractionsData) {
  const express = require('express');
  const fractionsConroller = require('../controllers/fractions-controller')(fractionsData);

  const fractionsRouter = new express.Router();
  fractionsRouter
    .get('/', fractionsConroller.index)
    .post('/', fractionsConroller.index)    
    .get('*', (req, res) => res.redirect('/fractions'));

  app.use('/fractions', fractionsRouter);
};