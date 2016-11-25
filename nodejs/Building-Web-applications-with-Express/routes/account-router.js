const express = require('express');
const passport = require('passport');
module.exports = function (app, userData) {
  const accountRouter = new express.Router();

  const accountController = require('../controllers/account-controller')(userData);
  accountRouter
    .get('/', accountController.index)
    .post('/', passport.authenticate('local', {
      failureRedirect: '/unauthorized'
    }), accountController.login)
    .get('/register', accountController.registerForm)
    .post('/register', accountController.register)
    .get('/logout', accountController.logout);

  app.use('/account', accountRouter);
};