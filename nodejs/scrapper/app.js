/* globals require console */
const request = require('request');

const jsdom = require('jsdom').jsdom;
const doc = jsdom();
const window = doc.defaultView;
const $ = require('jquery')(window);

const selector = 'div.leftCol li.info h3 a';
const url = 'http://www.dnevnik.bg/allnews/today/?ref=rightmenu';
request(url, (err, response, body) => {
  $('body').html(body);
  $(selector).each((index, item) => {
    console.log($(item).attr('href'));
  });
});