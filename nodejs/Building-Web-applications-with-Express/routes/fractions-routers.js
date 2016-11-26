'use strict';

module.exports = function (app, fractionData) {
  const express = require('express');

  const fractionsRouter = new express.Router();
  fractionsRouter
    .get('*', (req, res) => res.redirect('/fractions'));

  app.use('/fractions', fractionsRouter);
};