const express = require('express');

module.exports = function () {
  const app = express();

  app.set('view engine', 'pug');
  app.use(express.static('public'));

  return app;
};