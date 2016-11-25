'use strict';

const express = require('express');
const expressSession = require('express-session');
const cookieParser = require('cookie-parser');
const bodyParser = require('body-parser');

module.exports = function () {
  const app = express();

  app.set('view engine', 'pug');

  app.use(cookieParser());
  app.use(bodyParser.json());
  app.use(bodyParser.urlencoded({
    extended: true
  }));

  app.use(expressSession({
    secret: 'super duper secret',
    resave: true,
    saveUninitialized: true
  }));

  app.use(express.static('public'));

  return app;
};