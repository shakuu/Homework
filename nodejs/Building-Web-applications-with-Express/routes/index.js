const applyUsersRouter = require('./users-router');

module.exports = function (app) {
  applyUsersRouter(app);
};