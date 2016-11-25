const express = require('express');

module.exports = function (app, userData) {
  const accountRouter = new express.Router();

  const accountController = require('../controllers/account-controller')(userData);
  accountRouter
    .get('/', accountController.index)
    .post('/', accountController.login)
    .put('/', accountController.register);

  app.use('/account/', accountRouter);
};