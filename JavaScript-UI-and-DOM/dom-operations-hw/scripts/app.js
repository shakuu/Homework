// Create a function that takes an id or DOM element and an array of contents
// If an id is provided, select the element
// Add divs to the element
// Each div's content must be one of the items from the contents array
// The function must remove all previous content from the DOM element provided

var notStringError = Error('parameter not a string');

function populateElelemnt(element, contentArray) {
    console.log('called');
    if (typeof element !== 'string') {
        throw Error('bad string');
    }
}