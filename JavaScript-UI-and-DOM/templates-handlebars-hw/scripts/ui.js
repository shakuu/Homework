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
                    'background-color': 'rgba(33,33,33,0.8)'
                }).on('click', function () {
                    $(this)
                        .fadeToggle(1000);

                    removeElement(this, 1000);
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
                            && $(this).position().left - originalPosition.left > 0) {

                            moveLeft = false;
                            moveRight = true;

                            // slideElementOffTheScreen(this, 'right');
                            // removeElement($(this), 1000);

                            console.log('display prev');
                        } else if ($(this).position().left < originalPosition.left
                            && originalPosition.left - $(this).position().left > 0) {

                            moveLeft = true;
                            moveRight = false;

                            // slideElementOffTheScreen(this, 'left');
                            // removeElement(this, 1000);

                            console.log('display next');
                        } else {
                            moveLeft = false;
                            moveRight = false;
                        }
                    },
                    stop: function () {
                        var side = '';
                        if (moveRight) {
                            side = 'right';
                        } else {
                            side = 'left';
                        }

                        if (moveLeft || moveRight) {
                            $(this).draggable({
                                revert: false
                            }).hide('slide', { direction: side + '' }, 750, function () {
                                let newSrc = '',
                                    direction = '';

                                if (moveLeft) {
                                    clicked = $(clicked).parent().next().children('img').first();
                                    direction = 'right';
                                } else if (moveRight) {
                                    clicked = $(clicked).parent().prev().children('img').first();
                                    direction = 'left';
                                }

                                newSrc = clicked.attr('src');

                                slideElementOnTheScreen(this, direction);
                                $(this).attr('src', newSrc);
                            });
                        }
                    }
                })
                .css({
                    'width': '80%',
                    'padding': '10%'
                })
                .appendTo(display);

            display
                .hide()
                .appendTo('body')
                .fadeIn(1000);

            function slideElementOnTheScreen(element, side) {
                $(element).draggable({
                    revert: true
                }).show('slide', { direction: side + '' }, 750, function () {

                });
            }
        });

}



function removeElement(element, timeout) {
    setTimeout(function () {
        $(element).remove();
    }, +timeout);
}
