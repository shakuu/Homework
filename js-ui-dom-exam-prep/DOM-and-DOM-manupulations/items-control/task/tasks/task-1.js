function solve() {
    return function (selector, isCaseSensitive) {
        var element,
            fragment,

            addControls,
            addLabel,
            addInput,
            addButton,

            searchControls,
            searchLable,
            searchInput,

            resultControls,
            resultItemsList,

            templateListItem,
            templateButton,
            templateText,

            allListItems;

        // Select Element
        isCaseSensitive = !!isCaseSensitive;

        if (typeof selector === 'string') {
            element = document.querySelector(selector);
        } else if (selector instanceof HTMLElement) {

        } else {
            return;
        }
        element.className += ' items-control';

        fragment = document.createDocumentFragment();

        // Create AddControls
        addButton = document.createElement('a');
        addButton.className = 'button';
        addButton.innerHTML = 'Add';

        addInput = document.createElement('input');

        addLabel = document.createElement('label');
        addLabel.innerHTML = 'Enter text';
        addLabel.appendChild(addInput);

        addControls = document.createElement('div');
        addControls.className = 'add-controls';
        addControls.appendChild(addLabel);
        addControls.appendChild(addButton);

        // Create SearchControls
        searchInput = document.createElement('input');

        searchLable = document.createElement('label');
        searchLable.innerHTML = 'Search:';
        searchLable.appendChild(searchInput);

        searchControls = document.createElement('div');
        searchControls.className = 'search-controls';
        searchControls.appendChild(searchLable);

        // Create ResultControls
        resultItemsList = document.createElement('ul');
        resultItemsList.className = 'items-list';

        resultControls = document.createElement('div');
        resultControls.className = 'result-controls';
        resultControls.appendChild(resultItemsList);

        // Append all controls to Element.
        fragment.appendChild(addControls);
        fragment.appendChild(searchControls);
        fragment.appendChild(resultControls);
        element.appendChild(fragment);

        // Create ListItemTemplate
        templateButton = document.createElement('a');
        templateButton.className = 'button remove';
        templateButton.innerHTML = 'X';

        templateText = document.createElement('strong');

        templateListItem = document.createElement('li');
        templateListItem.className = 'list-item';
        templateListItem.appendChild(templateButton);
        templateListItem.appendChild(templateText);

        // Init allListItems live node list
        allListItems = document.getElementsByClassName('list-item');

        // Events
        addButton.addEventListener('click', addNewListItem);
        resultItemsList.addEventListener('click', removeItemList);
        searchInput.addEventListener('input', updateResults);

        // Event handling functions
        function addNewListItem() {
            var inputText,
                newItem;

            inputText = addInput.value;
            addInput.value = '';

            templateText.innerHTML = inputText;
            newItem = templateListItem.cloneNode(true);
            resultItemsList.appendChild(newItem);
        }

        function removeItemList(event) {
            var clicked,
                parent;

            clicked = event.target;
            if (clicked.className.indexOf('remove') < 0) {
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

        function updateResults(event) {
            var query = searchInput.value;

            if (!isCaseSensitive) {
                query = query.toLowerCase();
            }

            for (var index = 0, len = allListItems.length; index < len; index += 1) {
                var listItemStrongElement,
                    listItemStrongContent;

                listItemStrongElement = allListItems[index].querySelector('strong');
                listItemStrongContent = listItemStrongElement.innerHTML;

                if (!isCaseSensitive) {
                    listItemStrongContent = listItemStrongContent.toLowerCase();
                }

                if (listItemStrongContent.indexOf(query) >= 0) {
                    allListItems[index].style.display = '';
                } else {
                    allListItems[index].style.display = 'none';
                }
            }
        }
    };
}

module.exports = solve;
