'use strict';

const applyUsersRouter = require('./users-router');
const applyHomeRouter = require('./home-router');
const applyAccountRouter = require('./account-router');
const applySuperheroRouter = require('./superhero-router');
const applyFractionsRouter = require('./fractions-routers');

module.exports = function (app, data) {
  applyUsersRouter(app, data);
  applyHomeRouter(app);
  applyAccountRouter(app, data.userData);
  applySuperheroRouter(app, data.superheroesData);
  applyFractionsRouter(app, data.fractionsData);

  app.get('*', (req, res) => res.redirect('/'));
};