function getElement(element) {
    var selectedElement;

    if (!element.tagName) {
        if (typeof element !== 'string') {
            throw Error('Input parameter must be a string or a DOM element.');
        }

        selectedElement = document.getElementById(element);
    } else {
        selectedElement = document.getElementById(element.getAttribute('id'));
    }

    if (!selectedElement) {
        throw Error('Provided element must already exist.');
    }

    return selectedElement;
}

function toggleVisibilityOfContent(sender) {
    var nextElement = sender.nextElementSibling;

    while (true) {

        if (nextElement) {
            if (nextElement.className === 'button') {
                break;
            }

            if (nextElement.className === 'content') {
                // toggle visibility
                if (nextElement.style.display === 'none') {
                    nextElement.style.display = 'block';
                    sender.innerText = 'hide';
                } else {
                    nextElement.style.display = 'none';
                    sender.innerText = 'show';
                }

                break;
            }
        }
        else {
            break;
        }

        nextElement = nextElement.nextElementSibling;
    }
}

function eventModel(element) {
    var selectedElement = getElement(element);

    var buttonElements = selectedElement
        .getElementsByClassName('button');

    for (let i = 0; i < buttonElements.length; i += 1) {
        buttonElements[i].innerText = 'show';

        buttonElements[i].addEventListener('click', function () {
            toggleVisibilityOfContent(this);
        });
    }
}