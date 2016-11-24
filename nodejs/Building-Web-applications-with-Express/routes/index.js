const applyUsersRouter = require('./users-router');
const applyHomeRouter = require('./home-router');

module.exports = function (app, data) {
  applyUsersRouter(app, data);
  applyHomeRouter(app);
};