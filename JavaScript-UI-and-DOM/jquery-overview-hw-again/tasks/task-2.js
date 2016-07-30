/* globals $ */

/*
Create a function that takes a selector and:
* Finds all elements with class `button` or `content` within the provided element
  * Change the content of all `.button` elements with "hide"
* When a `.button` is clicked:
  * Find the topmost `.content` element, that is before another `.button` and:
    * If the `.content` is visible:
      * Hide the `.content`
      * Change the content of the `.button` to "show"       
    * If the `.content` is hidden:
      * Show the `.content`
      * Change the content of the `.button` to "hide"
    * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
* Throws if:
  * The provided ID is not a **jQuery object** or a `string` 

*/
function solve() {
    return function (selector) {
        var allButtons;

        if (typeof selector !== 'string' || !selector.length || $(selector).length === 0) {
            throw new Error();
        }

        allButtons = $(selector).children('.button');
        allButtons.html('hide');

        $(selector).on('click', function (event) {
            var clicked = $(event.target);

            if (clicked.hasClass('button')) {
                toggleContentVisibility(clicked);
            }
        });

        function toggleContentVisibility(button) {
            var $button = $(button),
                content;

            content = $button;

            while (!content.hasClass('content')) {
                content = content.next();

                if (content.hasClass('button')) {
                    return;
                }
            }


            if ($button.html() === 'hide') {
                $button.html('show');
                content.css({
                    'display': 'none'
                });
            } else {
                $button.html('hide');
                content.css({
                    'display': ''
                });
            }
        }
    };
}

module.exports = solve;