const express = require('express');

module.exports = function (app) {
  const homeController = require('../controllers/home-controller.js')();
  const homeRouter = new express.Router();
  homeRouter.get('/', homeController.index);
  app.use(homeRouter);
};