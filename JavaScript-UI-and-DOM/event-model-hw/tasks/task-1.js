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

        buttonElements = element.querySelectorAll('.button');

        for (i = 0; i < buttonElements.length; i += 1) {
            buttonElements[i].innerHTML = 'hide';
        }

        // ATTACH EVENT TO PARENT !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        element.addEventListener('click', toggleVisibilityOfContent);

        function toggleVisibilityOfContent(sender) {
            var nextElement = sender.target.nextElementSibling;

            while (true) {

                if (nextElement) {
                    if (nextElement.className.indexOf('button') >= 0) {
                        return;
                    }

                    if (nextElement.className.indexOf('content') >= 0) {
                        // toggle visibility
                        if (nextElement.style.display === 'none') {
                            nextElement.style.display = '';
                            sender.target.innerHTML = 'hide';
                        } else {
                            nextElement.style.display = 'none';
                            sender.target.innerHTML = 'show';
                        }

                        return;
                    }
                }
                else {
                    return;
                }

                nextElement = nextElement.nextElementSibling;
            }
        }
    }



    return solution;
}
