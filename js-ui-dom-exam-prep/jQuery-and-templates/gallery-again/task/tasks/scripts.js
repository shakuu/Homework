/* globals $ */

function solve() {
    $.fn.gallery = function (optional) {
        // your solution here
        var root = $(this),

            galleryList,
            allImageContainers,

            selected,
            disabledBackground,

            currentIndex,
            prev, next;

        optional = optional || 4;
        root.addClass('gallery');
        
        galleryList = root.children('.gallery-list');
        allImageContainers = galleryList.find('.image-container');

        selected = root.children('.selected').hide();

        disabledBackground = $('<div />').addClass('disabled-background');

        [].forEach.call(allImageContainers, function (el, i) {
            if (i % optional === 0) {
                allImageContainers.eq(i).addClass('clearfix');
            }
        });

        galleryList.on('click', '.image-container', displaySelectedImage);

        function displaySelectedImage(event) {
            var clicked = $(event.target);

            currentIndex = clicked.data('info') - 1;
            applySelectedImageUrl(currentIndex);

            selected.show();
            galleryList.addClass('blurred');
            disabledBackground.appendTo(root);
        }

        function applySelectedImageUrl(index) {
            var prev, next, current;
            current = index;
            prev = getPrevIndex(current);
            next = getNextIndex(current);

            displayImages({
                current: current,
                prev: prev,
                next: next
            });
        }

        function displayImages(options) {
            selected
                .children('.current-image')
                .children('img')
                .attr('src', allImageContainers.eq(options.current).children('img').first().attr('src'));

            selected
                .children('.previous-image')
                .children('img')
                .attr('src', allImageContainers.eq(options.prev).children('img').first().attr('src'));

            selected
                .children('.next-image')
                .children('img')
                .attr('src', allImageContainers.eq(options.next).children('img').first().attr('src'));
        }

        function getNextIndex(index) {
            var result = index + 1;

            if (result >= allImageContainers.length) {
                result = 0;
            }
            return result;
        }

        function getPrevIndex(index) {
            var result = index - 1;

            if (result < 0) {
                result = allImageContainers.length - 1;
            }
            return result;
        }

        selected.children('.current-image').on('click', function () {
            selected.hide();
            galleryList.removeClass('blurred');
            disabledBackground.remove();
        });

        selected.children('.next-image').on('click', function () {
            currentIndex = getNextIndex(currentIndex);
            applySelectedImageUrl(currentIndex);
        });

        selected.children('.previous-image').on('click', function () {
            currentIndex = getPrevIndex(currentIndex);
            applySelectedImageUrl(currentIndex);
        });

        return $(this);
    };
}
module.exports = solve;