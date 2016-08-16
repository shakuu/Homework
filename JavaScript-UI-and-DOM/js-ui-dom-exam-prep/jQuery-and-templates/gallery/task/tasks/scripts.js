/* globals $ */

function solve() {
    $.fn.gallery = function (optional) {
        // your solution here
        var rows,
            element,

            imagesList,
            allImageContainers,

            selectedContainer,
            previousContainer,
            currentContainer,
            nextContainer,
            previous,
            current,
            next;

        element = $(this);
        element.addClass('gallery');

        rows = +optional ? +optional : 4;

        allImageContainers = $('.image-container');
        for (var i = rows, len = allImageContainers.length; i < len; i += 1) {
            var cur = $(allImageContainers[i]);
            cur.addClass('clearfix');
        }

        imagesList = element.find('.gallery-list');
        selectedContainer = $('.selected');
        selectedContainer.hide();

        previousContainer = selectedContainer.find('.previous-image');
        currentContainer = selectedContainer.find('.current-image');
        nextContainer = selectedContainer.find('.next-image');

        // Events
        imagesList.on('click', showSelected);

        function showSelected(event) {
            var clicked = $(event.target),
                element;

            if (clicked.hasClass('image-container')) {
                element = clicked;
            } else if (clicked.parents('.image-container').length > 0) {
                element = clicked.parents('.image-container').first();
            } else {
                return;
            }

            assignElements(element);

            previousContainer.children('img').first().attr('src', previous.children('img').first().attr('src'));
            currentContainer.children('img').first().attr('src', current.children('img').first().attr('src'));
            nextContainer.children('img').first().attr('src', next.children('img').first().attr('src'));
            selectedContainer.show();

            imagesList.addClass('blurred');
        }

        currentContainer.on('click', function () {
            selectedContainer.hide();
            imagesList.removeClass('blurred');
        });

        previousContainer.on('click', function () {
            assignElements(previous);
            previousContainer.children('img').first().attr('src', previous.children('img').first().attr('src'));
            currentContainer.children('img').first().attr('src', current.children('img').first().attr('src'));
            nextContainer.children('img').first().attr('src', next.children('img').first().attr('src'));
        });

        nextContainer.on('click', function () {
            assignElements(next);
            previousContainer.children('img').first().attr('src', previous.children('img').first().attr('src'));
            currentContainer.children('img').first().attr('src', current.children('img').first().attr('src'));
            nextContainer.children('img').first().attr('src', next.children('img').first().attr('src'));
        });

        function assignElements(element) {
            var input = $(element);

            current = input;
            previous = input.prev();
            next = input.next();

            if (previous.length === 0) {
                previous = imagesList.children('.image-container').last();
            }

            if (next.length === 0) {
                next = imagesList.children('.image-container').first();
            }
        }
    };
}
module.exports = solve;