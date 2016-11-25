'use strict';

module.exports = function (userData) {
  function index(req, res) {
    res
      .status(200)
      .render('./account/index', {
        result: '/account'
      });
  }

  function login(req, res) {
    res
      .send(req.body);
  }

  function registerForm(req, res) {
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
          .redirect('/');
      })
      .catch(() => {
        res
          .status(400);
      });
  }

  function logout(req, res) {
    res
      .send(req.body);
  }

  return {
    index,
    login,
    register,
    registerForm,
    logout
  };
};