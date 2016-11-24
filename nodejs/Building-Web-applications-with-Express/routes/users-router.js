const express = require('express');

module.exports = function (app, data) {
  const usersRouter = new express.Router();
  const usersController = require('../controllers/user-controller')(data);

  usersRouter.get('/', usersController.index);

  app.use('users', usersRouter);
};