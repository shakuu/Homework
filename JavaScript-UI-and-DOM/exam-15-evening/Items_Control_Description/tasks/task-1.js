function solve() {
    return function (selector, isCaseSensitive) {
        var container = selector,
            fragment,

            addControls,
            addLabel,
            addInput,
            addButton,

            searchControls,
            searchLabel,
            searchInput,

            resultControls,
            resultItemsList,

            listItemTemplate,
            listItemStrong,
            listItemButton,

            allListItems;

        isCaseSensitive = !!isCaseSensitive;
        container = document.querySelector(container);
        fragment = document.createDocumentFragment();

        if (!container) {
            throw new Error();
        }

        container.className = 'items-control';

        // add-controls
        addControls = document.createElement('div');
        addControls.className = 'add-controls';

        addLabel = document.createElement('label');
        addLabel.innerHTML = 'Enter text:';

        addInput = document.createElement('input');
        addInput.className = 'add-input';

        addButton = document.createElement('a');
        addButton.className = 'button';
        addButton.innerHTML = 'Add';

        addLabel.appendChild(addInput);

        addControls.appendChild(addLabel);
        addControls.appendChild(addButton);
        fragment.appendChild(addControls);

        // search-controls
        searchControls = document.createElement('div');
        searchControls.className = 'search-controls';

        searchLabel = document.createElement('label');
        searchLabel.innerHTML = 'Search:';

        searchInput = document.createElement('input');
        searchInput.id = 'search-input';

        searchLabel.appendChild(searchInput);
        searchControls.appendChild(searchLabel);
        fragment.appendChild(searchControls);

        // result-controls
        resultControls = document.createElement('div');
        resultControls.className = 'result-controls';

        resultItemsList = document.createElement('ul');
        resultItemsList.className = 'items-list';

        resultControls.appendChild(resultItemsList);
        fragment.appendChild(resultControls);

        // list-item template
        listItemTemplate = document.createElement('li');
        listItemTemplate.className = 'list-item';

        listItemStrong = document.createElement('strong');

        listItemButton = document.createElement('a');
        listItemButton.className = 'button';
        listItemButton.className += ' delete-button';
        listItemButton.innerHTML = 'X';

        listItemTemplate.appendChild(listItemButton);
        listItemTemplate.appendChild(listItemStrong);

        // add all to container
        container.appendChild(fragment);

        // Attach Events
        addControls.addEventListener('click', addListItem);
        searchInput.addEventListener('input', filterListItemsByName);
        resultControls.addEventListener('click', removeClickedListItem);
        allListItems = document.getElementsByClassName('list-item');

        function addListItem(event) {
            var clicked = event.target,
                listItemText;

            if (!clicked || clicked.className.indexOf('button') < 0) {
                return;
            }

            listItemText = addInput.value;
            addInput.value = '';

            listItemStrong.innerHTML = listItemText;
            resultItemsList.appendChild(listItemTemplate.cloneNode(true));
        }

        function filterListItemsByName() {
            var text = searchInput.value,
                filter,
                length,
                listItemText,
                i;

            if (isCaseSensitive) {
                filter = text;
            } else {
                filter = text.toLowerCase();
            }

            length = allListItems.length;
            for (i = 0; i < length; i += 1) {
                listItemText = allListItems[i].querySelector('strong').innerHTML;

                if (!isCaseSensitive) {
                    listItemText = listItemText.toLowerCase();
                }

                if (listItemText.indexOf(filter) < 0) {
                    allListItems[i].style.display = 'none';
                } else {
                    allListItems[i].style.display = '';
                }
            }
        }

        function removeClickedListItem(event) {
            var clicked = event.target,
                parent;

            if (!clicked || clicked.className.indexOf('delete-button') < 0) {
                return;
            }

            parent = clicked;
            while (parent && parent.className.indexOf('list-item') < 0) {
                parent = parent.parentNode;
            }
            if (!parent) {
                return;
            }
            parent.parentNode.removeChild(parent);
        }
    };
}

module.exports = solve;