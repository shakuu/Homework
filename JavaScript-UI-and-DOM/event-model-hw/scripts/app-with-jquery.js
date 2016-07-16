function getElement(element) {
    let outputElement;

    if (!element.tagName) {
        if (typeof element !== 'string') {
            throw Error('Input parameter must be a string or a DOM element.');
        }

        outputElement = element;
    } else {
        outputElement = element.id;
    }

    if (!document.getElementById(outputElement)) {
        throw Error('Provided element must already exist.');
    }

    return outputElement;
}

function eventModel(element) {

    $('#' + getElement(element))
        .on('click', '.button', function (args) {
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