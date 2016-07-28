/* globals module, document, HTMLElement, console */

function solve() {
    return function (selector, isCaseSensitive) {
        var element = selector,

            addControls,
            addLabel,
            addInput,
            addBtn,

            searchControls,
            searchLabel,
            searchInput,

            resultsControls,
            itemsList,

            listItemTemplate,
            listItemText,
            listItemButton,
            listItemsLiveNodeList;

        // Cast isCaseSensitive to bool
        isCaseSensitive = !!isCaseSensitive;

        // Validate selector
        if (typeof element === 'string') {
            element = document.querySelector(element);
        } else if (element instanceof HTMLElement) {
            // do nothing
        } else {
            throw new Error();
        }
        element.className += " items-control";

        // Add Section
        addControls = document.createElement('div');
        addControls.className = "add-controls";

        addLabel = document.createElement('label');
        addLabel.innerHTML = "Enter text: ";

        addInput = document.createElement('input');
        addLabel.appendChild(addInput);

        addBtn = document.createElement('a');
        addBtn.className = 'button';
        addBtn.innerHTML = 'Add';
        addBtn.style.display = 'inline-block';
        addBtn.addEventListener('click', onAddBtnClick, false);

        addControls.appendChild(addLabel);
        addControls.appendChild(addBtn);

        element.appendChild(addControls);

        // Search Section
        searchControls = document.createElement('div');
        searchControls.className = "search-controls";

        searchLabel = document.createElement('label');
        searchLabel.innerHTML = 'Search: ';

        searchInput = document.createElement('input');
        searchInput.addEventListener('input', onInputUpdate, false);

        searchLabel.appendChild(searchInput);
        searchControls.appendChild(searchLabel);
        element.appendChild(searchControls);

        // Items List
        resultsControls = document.createElement('div');
        resultsControls.className = 'result-controls';
        resultsControls.addEventListener('click', onDeleteButtonClick, false);                

        itemsList = document.createElement('ul');
        itemsList.className = "items-list";

        resultsControls.appendChild(itemsList);
        element.appendChild(resultsControls);

        // List Item
        listItemTemplate = document.createElement('li');
        listItemTemplate.className = 'list-item';

        listItemButton = document.createElement('a');
        listItemButton.className = 'button delete-button';
        listItemButton.innerHTML = 'X';

        listItemText = document.createElement('strong');

        listItemTemplate.appendChild(listItemButton);
        listItemTemplate.appendChild(listItemText);

        listItemsLiveNodeList = document.getElementsByClassName('list-item');

        function onAddBtnClick(event) {
            var text = addInput.value;
            addInput.value = '';

            listItemText.innerHTML = text;

            itemsList.appendChild(listItemTemplate.cloneNode(true));
        }

        function onInputUpdate(event) {
            var search = searchInput.value + '',
                i;

            if (!isCaseSensitive) {
                search = search.toLowerCase();
            }

            for (i = 0; i < listItemsLiveNodeList.length; i += 1) {
                var value = listItemsLiveNodeList[i].getElementsByTagName('strong')[0].innerHTML;

                if (!isCaseSensitive) {
                    value = value.toLowerCase();
                }

                if (value.indexOf(search) >= 0) {
                    listItemsLiveNodeList[i].style.display = '';
                } else {
                    listItemsLiveNodeList[i].style.display = 'none';
                }
            }
        }

        function onDeleteButtonClick(event) {
            var deleteBtn = event.target,
                parent;

            if (deleteBtn.className.indexOf('delete-button') < 0) {
                return;
            }

            parent = deleteBtn;
            while (parent && parent.className.indexOf('list-item') < 0) {
                parent = parent.parentNode;
            }

            if (!parent) {
                return;
            }

            itemsList.removeChild(parent);
        }
    };
}

module.exports = solve;
