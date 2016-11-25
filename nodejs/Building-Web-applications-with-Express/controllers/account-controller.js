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