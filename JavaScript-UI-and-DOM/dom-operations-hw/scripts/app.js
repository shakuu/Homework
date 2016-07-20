// Create a function that takes an id or DOM element and an array of contents
// If an id is provided, select the element
// Add divs to the element
// Each div's content must be one of the items from the contents array
// The function must remove all previous content from the DOM element provided

function solve() {
    function task1(el, content) {

        if (typeof el === 'string') {
            el = document.getElementById(el);

            if (el === null) {
                throw new Error();
            }

        } else if (el instanceof HTMLElement) {
            // nothing
        } else {
            throw new Error();
        }

        if (!Array.isArray(content)) {
            throw new Error();
        }

        var outputContent = '';
        for (var i = 0; i < content.length; i += 1) {

            if (typeof content[i] !== 'string' && typeof content[i] !== 'number') {
                throw new Error();
            }

            outputContent += '<div>' + content[i] + '</div>';
        }
        el.innerHTML = outputContent;
    }

    return task1;
}