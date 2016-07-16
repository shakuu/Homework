function validateElement(element) {
    let outputElement;

    if (!(element instanceof jQuery)) {
        if (typeof element !== 'string') {
            throw Error('Input parameter must be a string or a jQuery object.');
        }
    }
}

function eventModel(element) {
    validateElement(element);

    $(element).on('click', '.button', function (args) {
        let button = $(this);

        button.next('.content').slideToggle(1200);

        if (button.text() !== 'show') {
            button.text('show');
        } else {
            button.text('hide');
        }
    })
        .children('.button')
        .text('show');
}