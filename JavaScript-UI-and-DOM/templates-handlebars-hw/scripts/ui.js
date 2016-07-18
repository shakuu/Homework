function addThumbs() {

    let booksList = $('.animals-list');

    for (let i = 0; i < booksList.children().length; i += 1) {
        $('<img>')
            .css({
                'width': '100px',
                'height': '100px'
            }).attr('src', $(booksList.children()[i]).children('a').first().attr('href'))
            .prependTo($(booksList.children()[i]));
    }

    booksList.css('list-style', 'none')
        .children('li')
        .css('display', 'inline-block')
        .children('a')
        .css('display', 'none')
        .parent()
        .parent()
        .on('click', 'img', function () {
            let clicked = $(this);

            let display = $('<div>')
                .addClass('full-screen-display')
                .css({
                    'width': '100%',
                    'height': '100%',
                    'position': 'absolute',
                    'left': '0',
                    'top': '0',
                    'background-color': 'rgba(33,33,33,0.8)',
                    'padding': '10%'
                }).on('click', function () {
                    $(this)
                        .fadeToggle(1000)
                        .remove();
                });

            var moveLeft = false,
                moveRight = false,
                originalPosition,
                originalOffset;

            let img = $('<img>')
                .attr('src', clicked.attr('src'))
                .draggable({
                    revert: true,
                    axis: 'x',
                    scroll: false,
                    start: function (event, ui) {
                        originalPosition = $(this).position();
                        originalOffset = $(this).offset();
                    },
                    drag: function (event, ui) {
                        if ($(this).position().left > originalPosition.left
                            && $(this).position().left - originalPosition.left >= 150) {

                            moveLeft = false;
                            moveRight = true;
                        } else if ($(this).position().left < originalPosition.left
                            && originalPosition.left - $(this).position().left >= 150) {

                            moveLeft = true;
                            moveRight = false;
                        } else {
                            moveLeft = false;
                            moveRight = false;
                        }
                    },
                    stop: function () {
                        if (moveLeft) {
                            // display next photo
                            console.log('left');
                        } else if (moveRight) {
                            // display prev photo
                            console.log('right');
                        } else {
                            // nothing
                            console.log('do not move');
                        }
                    }
                })
                .css({
                    'width': '80%'
                })
                .appendTo(display);


            display
                .hide()
                .appendTo('body')
                .fadeIn(1000);
        });
}