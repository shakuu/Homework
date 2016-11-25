'use strict';

const LocalStrategy = require('passport-local');
const passport = require('passport');

module.exports = function (app, userData) {
  const strategy = new LocalStrategy((username, password, done) => {
    userData.findByUsername(username)
      .then((user) => {
        if (!user) {
          return done(null, false);
        }

        if (!user.verifyPassword(password)) {
          return done(null, false);
        }

        return done(null, user);
      });
  });

  passport.serializeUser((user, done) => {
    if (user) {
      done(null, user._id);
    }
  });

  passport.deserializeUser((id, done) => {
    userData.findById(id)
      .then((user) => {
        if (user) {
          return done(null, user);
        }

        return done(null, false);
      });
  });


  app.use(passport.initialize());
  app.use(passport.session());

  passport.use(strategy);
};