/* globals $ */

function solve() {
    $.fn.gallery = function (columns) {
        // your solution here
        var gallery,
            galleryList,
            allImages,

            numberOfRowsInGrid,

            selectedContainer = $('.selected').addClass('disabled-background').hide(),
            selectedCurrent = selectedContainer.children('.current-image'),
            selectedPrevious = selectedContainer.children('.previous-image'),
            selectedNext = selectedContainer.children('.next-image'),

            i, width,

            clicked,
            nextElement,
            prevElement;

        columns = +columns ? +columns : 4;

        gallery = $('#gallery').addClass('gallery');
        galleryList = $('.gallery-list');
        allImages = galleryList.children('.image-container');

        for (i = columns; i < allImages.length; i += columns) {
            $(allImages[i]).addClass('clearfix');
        }

        // Events
        gallery.on('click', function (event) {
            clicked = $(event.target);

            if (clicked.hasClass('image-container')) {

            } else if (clicked.parents('.image-container').length > 0) {
                clicked = clicked.parents('.image-container').first();
            } else {
                return;
            }

            nextElement = clicked.next().length > 0 ? clicked.next() : clicked.parents('.gallery-list').first().children().first();
            prevElement = clicked.prev().length > 0 ? clicked.prev() : clicked.parents('.gallery-list').first().children().last();

            selectedCurrent.children('img').first().attr({
                'src': clicked.children('img').first().attr('src'),
                'data-info': clicked.children('img').first().attr('data-info')
            });

            selectedPrevious.children('img').first().attr({
                'src': prevElement.children('img').first().attr('src'),
                'data-info': prevElement.children('img').first().attr('data-info')
            });

            selectedNext.children('img').first().attr({
                'src': nextElement.children('img').first().attr('src'),
                'data-info': nextElement.children('img').first().attr('data-info')
            });

            selectedContainer.show();

            galleryList.addClass('blurred');
        });

        selectedCurrent.on('click', function () {
            selectedContainer.hide();
            galleryList.removeClass('blurred');
        });

        selectedNext.on('click', function () {

            clicked = nextElement;

            nextElement = clicked.next().length > 0 ? clicked.next() : clicked.parents('.gallery-list').first().children().first();
            prevElement = clicked.prev().length > 0 ? clicked.prev() : clicked.parents('.gallery-list').first().children().last();

            selectedCurrent.children('img').first().attr({
                'src': clicked.children('img').first().attr('src')
            });

            selectedPrevious.children('img').first().attr({
                'src': prevElement.children('img').first().attr('src')
            });

            selectedNext.children('img').first().attr({
                'src': nextElement.children('img').first().attr('src')
            });
        });

        selectedPrevious.on('click', function () {

            clicked = prevElement;

            nextElement = clicked.next().length > 0 ? clicked.next() : clicked.parents('.gallery-list').first().children().first();
            prevElement = clicked.prev().length > 0 ? clicked.prev() : clicked.parents('.gallery-list').first().children().last();

            selectedCurrent.children('img').first().attr({
                'src': clicked.children('img').first().attr('src')
            });

            selectedPrevious.children('img').first().attr({
                'src': prevElement.children('img').first().attr('src')
            });

            selectedNext.children('img').first().attr({
                'src': nextElement.children('img').first().attr('src')
            });
        });
        return $(this);
    };
}
module.exports = solve;