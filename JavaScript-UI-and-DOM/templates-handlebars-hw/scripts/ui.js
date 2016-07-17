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
                    'padding':'10%'
                }).on('click', function(){
                    $(this).remove();
                });

            let img = $('<img>')
                .attr('src', clicked.attr('src'))
                .css({
                    'width': '80%'
                })
                .appendTo(display);

            display.appendTo('body');
        });
}