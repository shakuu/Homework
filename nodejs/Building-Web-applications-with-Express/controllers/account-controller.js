'use strict';

module.exports = function (userData) {
  function index(req, res) {
    if (req.isAuthenticated()) {
      res
        .status(200)
        .redirect('/account/profile');
    }

    res
      .status(200)
      .render('./account/index', {
        result: '/account/login'
      });
  }

  function login(req, res) {
    res.redirect('/account/profile');
  }

  function registerForm(req, res) {
    if (req.isAuthenticated()) {
      res
        .status(200)
        .redirect('/account/profile');
    }

    res
      .status(200)
      .render('./account/index', {
        result: '/account/register'
      });
  }

  function register(req, res) {
    const inputUser = req.body;

    userData.create(inputUser)
      .then(() => {
        res
          .status(201)
          .redirect('/account');
      })
      .catch(() => {
        res
          .status(400);
      });
  }

  function logout(req, res) {
    req.logout();
    res
      .status(200)
      .redirect('/account/login');
  }

  function profile(req, res) {
    if (!req.isAuthenticated()) {
      return res
        .status(401)
        .redirect('/account/login');
    }

    return res
      .status(200)
      .render('./account/profile', {
        result: req.user
      });
  }

  function updateImage(req, res) {
    userData.updateImage(req.user, req.body.image)
      .then(() => {
        res
          .status(200)
          .redirect('/account/profile');
      })
      .catch((err) => {
        res
          .status(400)
          .send(err);
      });
  }

  function updateDisplayName(req, res) {
    userData.updateDisplayName(req.user, req.body.displayName)
      .then(() => {
        res
          .status(200)
          .redirect('/account/profile');
      })
      .catch((err) => {
        res
          .status(400)
          .send(err);
      });
  }

  return {
    index,
    login,
    register,
    registerForm,
    logout,
    profile,
    updateImage,
    updateDisplayName
  };
};