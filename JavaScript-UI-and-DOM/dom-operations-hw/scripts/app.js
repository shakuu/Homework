// Create a function that takes an id or DOM element and an array of contents
// If an id is provided, select the element
// Add divs to the element
// Each div's content must be one of the items from the contents array
// The function must remove all previous content from the DOM element provided

function populateElelemnt(element, contentArray) {
    var selectedElement;

    if (!element) {
        throw Error('parameter [element] must be present');
    }

    if (!contentArray) {
        throw Error('parameter [contentArray] must be present');
    }

    if (!Array.isArray(contentArray)) {
        throw Error('contentArray must be an array');
    }

    if (typeof element !== 'string' && !element.tagName) {
        throw Error('element not a string or DOM element');
    }

    if (element.tagName && !document.getElementById('#' + element.getAttribute('id'))) {
        throw Error('not an existing DOM element');
    }

    if ($(element).length === 0) {
        throw Error('element with this ID does not exist');
    }

    for (let i in contentArray) {
        if (typeof contentArray[i] !== 'string' && typeof contentArray[i] !== 'number') {
            throw Error('content must be of type string or number');
        }
    }
}