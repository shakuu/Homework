const applyUsersRouter = require('./users-router');
const applyHomeRouter = require('./home-router');
const applyAccountRouter = require('./account-router');

module.exports = function (app, data) {
  applyUsersRouter(app, data);
  applyHomeRouter(app);
  applyAccountRouter(app, data.userData);

  app.get('*', (req, res) => res.redirect('/'));
};