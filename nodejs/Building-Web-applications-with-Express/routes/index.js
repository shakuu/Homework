const applyUsersRouter = require('./users-router');
const applyHomeRouter = require('./home-router');

module.exports = function (app) {
  applyUsersRouter(app);
  applyHomeRouter(app);
};