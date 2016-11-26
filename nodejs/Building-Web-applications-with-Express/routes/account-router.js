'use strict';

const express = require('express');
const passport = require('passport');

module.exports = function (app, userData) {
  const accountRouter = new express.Router();

  const accountController = require('../controllers/account-controller')(userData);
  accountRouter
    .get('/profile', accountController.profile)
    .get('/login', accountController.index)
    .post('/login', passport.authenticate('local', {
      failureRedirect: '/unauthorized'
    }), accountController.login)
    .get('/register', accountController.registerForm)
    .post('/register', accountController.register)
    .get('/logout', accountController.logout)
    .post('/image', accountController.updateImage)
    .post('/displayName', accountController.updateDisplayName)
    .get('/remove/hero/:superheroName', accountController.removeFavoriteSuperhero)
    .get('/remove/fraction/:fractionName', accountController.removeFavoriteFraction)
    .get('/', (req, res) => res.redirect('/account/profile'));

  app.use('/account', accountRouter);
};