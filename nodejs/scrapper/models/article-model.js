/* globals require module*/
'use strict';

const mongoose = require('mongoose');

const articleSchema = mongoose.Schema({
  title: {
    type: String,
    required: true
  },
  url: {
    type: String,
    required: true
  }
});

let Article;
Article.statics.getArticle = function (title, url) {
  return new Article({
    title: title,
    url: url
  });
};

mongoose.model('Article', articleSchema);
Article = mongoose.model('Article');

module.exports = Article;
