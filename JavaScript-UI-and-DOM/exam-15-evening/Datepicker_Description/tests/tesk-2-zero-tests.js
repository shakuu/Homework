/*globals describe, it, require, before, global, $, jQuery*/

var expect = require('chai').expect;
var jsdom = require('jsdom');
var jq = require('jquery');

describe('Task #2 Zero Tests', function () {

  before(function (done) {
    jsdom.env({
      html: '',
      done: function (errors, window) {
        global.window = window;
        global.document = window.document;
        global.$ = jq(window);
        Object.keys(window)
          .filter(function (prop) {
            return prop.toLowerCase().indexOf('html') >= 0;
          }).forEach(function (prop) {
            global[prop] = window[prop];
          });
        done();
      }
    });
  });
  it('expect to add class .datepicker-wrapper', function () {
      var result = require('../tasks/task-2')();
      document.body.innerHTML = '<input type="text" id="date" />';
      $('#date').datepicker();
      var parent = $('input').parent();
      var parentClass = parent.hasClass('datepicker-wrapper');
      expect(parentClass).to.be.true;
      expect(parent.children().length).to.be.above(1);
  });
});