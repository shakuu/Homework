const express = require('express');

module.exports = function (app, data) {
  const usersController = require('../controllers/user-controller')(data.userData);

  const usersRouter = new express.Router();
  usersRouter.get('/', usersController.index);

  app.use('users', usersRouter);
};