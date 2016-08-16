/*globals describe, it, require, before, global, $*/
var expect = require('chai').expect;
var jsdom = require('jsdom');
var jq = require('jquery');
var result = require('../tasks/task-3')();
var handlebars = require('handlebars');

describe('Task #3 Tests', function () {

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

    // 0
    it('expect to generate the HTML with the example data', function () {
        document.body.innerHTML = '<script id="template"></script>';
        var $You_WhatIt_BUT_NO = $;
        $ = undefined; // disable jQuery for the result
        result('template');
        $ = $You_WhatIt_BUT_NO;

        var data = {
            year: 2015,
            month: 'August',
            days: [{
                day: 3,
                events: [{
                    duration: 765,
                    importance: 'none'
                }, {
                    title: 'My Event 1',
                    time: '12:45',
                    duration: 60,
                    comment: 'no comment',
                    importance: 'critical'
                }, {
                    duration: 15,
                    importance: 'none'
                }, {
                    title: 'My Event 2',
                    time: '14:00',
                    duration: 120,
                    comment: 'no comment',
                    importance: 'important'
                }, {
                    duration: 60,
                    importance: 'none'
                }, {
                    title: 'My Event 4',
                    time: '17:00',
                    duration: 60,
                    comment: 'no comment',
                    importance: 'unimportant'
                }, {
                    duration: 360,
                    importance: 'none'
                }]
            }, {
                day: 4,
                events: [{
                    duration: 750,
                    importance: 'none'
                }, {
                    title: 'Prepare for the Exam',
                    time: '12:30',
                    duration: 480,
                    comment: 'no comment',
                    importance: 'important'
                }, {
                    duration: 210,
                    importance: 'none'
                }],
            }, {
                day: 5,
                events: [{
                    duration: 1320,
                    importance: 'none'
                }, {
                    title: 'PARTY',
                    time: '22:00',
                    duration: 120,
                    comment: 'I must be there',
                    importance: 'unimportant'
                }],
            }, {
                day: 6,
                events: [{
                    title: 'PARTY',
                    time: '0:00',
                    duration: 180,
                    comment: 'I must be there',
                    importance: 'unimportant'
                }, {
                    duration: 390,
                    importance: 'none'
                }, {
                    title: 'JS UI & DOM Exam',
                    time: '9:30',
                    duration: 780,
                    comment: 'Keep your fingers crossed',
                    importance: 'critical'
                }, {
                    duration: 90,
                    importance: 'none'
                }],
            }, {
                day: 7,
                events: [{
                    title: 'Vacation',
                    time: '0:00',
                    duration: 1440,
                    comment: 'Finaly some time to relax',
                    importance: 'vacation'
                }],
            }, {
                day: 8,
                events: [{
                    title: 'Vacation',
                    time: '0:00',
                    duration: 1440,
                    comment: 'Finaly some time to relax',
                    importance: 'vacation'
                }],
            }, {
                day: 9,
                events: [{
                    title: 'Vacation',
                    time: '0:00',
                    duration: 1440,
                    comment: 'Finaly some time to relax',
                    importance: 'vacation'
                }],
            }]
        };

        var template = handlebars.compile($('#template').html());
        var compiledHTML = template(data);
        document.body.innerHTML = compiledHTML;

        var $calendar = $('.events-calendar');
        expect($calendar).to.has.length(1);

        var $header = $calendar.find('.header');
        expect($header).to.has.length(1);

        var $month = $header.find('.month');
        expect($month).to.has.length(1);
        expect($month[0].innerHTML).to.equal(data.month);

        var $year = $header.find('.year');
        expect($year).to.has.length(1);
        expect($year[0].innerHTML).to.equal(data.year + '');

        var $days = $calendar.find('.col-date');
        expect($days).to.has.length(data.days.length);

        var $events = $calendar.find('.event');
        expect($events).to.has.length(19);

        var $critical = $calendar.find('.event.critical');
        var $important = $calendar.find('.event.important');
        var $unimportant = $calendar.find('.event.unimportant');
        var $vacation = $calendar.find('.event.vacation');
        var $none = $calendar.find('.event.none');
        expect($critical).to.has.length(2);
        expect($important).to.has.length(2);
        expect($unimportant).to.has.length(3);
        expect($vacation).to.has.length(3);
        expect($none).to.has.length(9);
    });
});