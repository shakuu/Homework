function solve() {

    var displayType = '';

    function solution(element) {
        var contentElements,
            buttonElements,
            i;

        if (typeof element === 'string') {
            element = document.getElementById(element);

            if (!element) {
                throw new Error();
            }

        } else if (element instanceof HTMLElement) {

            if (!document.contains(element)) {
                throw new Error();
            }

        } else {
            throw new Error();
        }

        contentElements = element.getElementsByClassName('content');
        buttonElements = element.getElementsByClassName('button');

        if (contentElements.length > 0) {
            displayType = contentElements[0].style.display;

            if (!displayType) {
                displayType = 'block';
            }
        }

        for (i = 0; i < buttonElements.length; i += 1) {
            buttonElements[i].innerHTML = 'hide';

            buttonElements[i].onclick = function () {
                toggleVisibilityOfContent(this);
            };
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
                        if (nextElement.style.visibility === 'hidden') {
                            nextElement.style.visibility = 'visible';
                            sender.innerHTML = 'hide';
                        } else {
                            nextElement.style.visibility = 'hidden';
                            sender.innerHTML = 'show';
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
    }



    return solution;
}
