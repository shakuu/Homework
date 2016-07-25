function solve() {
    function solution(selector, isCaseSensitive) {
        buildAdd(selector);
        buildSearch(selector, isCaseSensitive);
        buildResult(selector);
    }

    function buildResult(selector) {
        var list,
            fragment;

        fragment = document.createElement('div');
        fragment.className = 'result-controls';

        list = document.createElement('ul');
        list.className = 'items-list';
        list.addEventListener('click', function (ev) {
            var el = ev.target;
            if (el instanceof HTMLAnchorElement) {
                el.parentNode.parentNode.removeChild(el.parentNode);
            }
        });
        fragment.appendChild(list);

        var root = document.querySelector(selector);
        root.appendChild(fragment);
    }

    function hideAllElementsWhichDoNotContainValue(value, isCaseSensitive) {
        var myRegex;

        if (!isCaseSensitive) {
            myRegex = RegExp(value, i);

            // value = (value + '').toLowerCase();
        } else {
            myRegex = RegExp(value);
        }

        var listItems = document
            .getElementById('root')
            .querySelectorAll('.items-list .list-item');

        for (var i = 0; i < listItems.length; i += 1) {
            var inner = listItems[i].innerHTML + '';

            // if (!isCaseSensitive) {
            //     inner = inner.toLowerCase();
            // }

            // if (inner.indexOf(value + '') < 0) {
            //     listItems[i].style.display = 'none';
            // }

            // if (inner.indexOf(value + '') >= 0) {
            //     listItems[i].style.display = '';
            // }

            if (myRegex.test(inner)) {
                listItems[i].style.display = '';
            } else {
                listItems[i].style.display = 'none';
            }
        }
    }

    function buildSearch(selector, isCaseSensitive) {
        var label,
            input,
            fragment;

        fragment = document.createElement('div');
        fragment.className = 'search-controls';

        label = document.createElement('label');
        label.for = 'search-input';
        label.innerHTML = 'Search:';
        fragment.appendChild(label);

        input = document.createElement('input');
        input.type = 'text';
        input.id = 'search-input';
        input.addEventListener('input', function () {
            hideAllElementsWhichDoNotContainValue(this.value, isCaseSensitive);
        });
        fragment.appendChild(input);

        var root = document.querySelector(selector);
        root.appendChild(fragment);
    }

    function buildAdd(selector) {
        var label,
            input,
            button,
            fragment;

        fragment = document.createElement('div');
        fragment.className = 'add-controls';

        label = document.createElement('label');
        label.for = 'add-input';
        label.innerHTML = 'Enter text';
        fragment.appendChild(label);

        input = document.createElement('input');
        input.type = 'text';
        input.id = 'add-input';
        fragment.appendChild(input);

        button = document.createElement('div');
        button.class = 'button';
        button.innerHTML = 'Add';
        button.addEventListener('click', function () {
            addNewListItem(selector);
        });
        fragment.appendChild(button);

        var root = document.querySelector(selector);
        root.appendChild(fragment);
    }

    function addNewListItem(selector) {
        var container,
            button,
            inputText,
            strong,
            textToAdd = '';

        inputText = document.querySelector(selector).querySelector('.add-controls input');
        textToAdd = inputText.value;
        inputText.value = '';

        container = document.createElement('li');
        container.className = 'list-item';

        button = document.createElement('a');
        button.href = '#';
        button.className = 'button';
        button.innerHTML = 'X';
        // button.addEventListener('click', function () {
        //     this.parentNode.parentNode.removeChild(this.parentNode);

        // });
        container.appendChild(button);

        strong = document.createElement('strong');
        strong.innerHTML += textToAdd;
        container.appendChild(strong);

        document.querySelector(selector)
            .querySelector('.items-list')
            .appendChild(container);
    }

    solution('#root', true);
    return solution;
}

solve();