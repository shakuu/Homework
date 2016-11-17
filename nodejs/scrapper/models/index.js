/* globals require module*/
'use strict';

const article = require('./article-model');

const factories = {
  getArticle: article.getArticle
};

module.exports = factories;