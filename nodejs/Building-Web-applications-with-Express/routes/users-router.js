const express = require('express');

module.exports = function (app) {
  const usersRouter = new express.Router();

  usersRouter.get('/', (req, res) => {
    res.send('users/index');
  });

  app.use('users', usersRouter);
};