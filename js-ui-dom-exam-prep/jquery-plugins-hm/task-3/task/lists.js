$.fn.lists = function (lists) {
    var element = $(this),

        sectionContainer,

        templateArticle,
        templateWrapper,
        templateName,
        templateButton,
        templateInput,
        templateList,
        templateItem,
        templateItemAnchor,

        urlTemplateString = 'https://www.google.com/search?q=',

        numberOfLists,
        numberOfItems,
        list, item,
        newListArticle,
        newItem,

        dragged;

    // Element wrapper
    sectionContainer = $('<section />')
        .addClass('lists-wrapper')
        .appendTo(element);

    // List Wrapper
    templateArticle = $('<article />')
        .addClass('items-section');

    // Strong Label
    templateName = $('<strong />')
        .appendTo(templateArticle);

    // Input 
    templateWrapper = $('<div />')
        .addClass('add-item-wrapper')
        .appendTo(templateArticle);
    templateButton = $('<a />')
        .addClass('visible')
        .addClass('add-btn')
        .appendTo(templateWrapper);
    templateInput = $('<input />')
        .attr('type', 'text')
        .addClass('add-input')
        .appendTo(templateWrapper);

    // List
    templateList = $('<ul />')
        .appendTo(templateArticle);
    // Inidividual Item
    templateItem = $('<li />')
        .attr('draggable', 'true');
    templateItemAnchor = $('<a />')
        .attr('target', '_blank')
        .appendTo(templateItem);

    // Fill in lists
    numberOfLists = lists.length;
    for (list = 0; list < numberOfLists; list += 1) {
        numberOfItems = lists[list].length;
        newListArticle = templateArticle.clone();
        newListArticle.children('strong').first().html(lists[list][0]);

        for (item = 1; item < numberOfItems; item += 1) {
            templateItemAnchor
                .html(lists[list][item])
                .attr('href', urlTemplateString + lists[list][item]);
            newItem = templateItem.clone();
            newListArticle.children('ul').first().append(newItem);
        }
        newListArticle.find('input').on('keydown', addNewItem);
        newListArticle.appendTo(sectionContainer);
    }

    sectionContainer.on('click', '.add-btn', displayInputElement);
    sectionContainer.on('drop', dropItem);
    sectionContainer.on('dragstart', 'li', function (event) {
        dragged = $(this);
    });

    function dropItem(event) {
        var target = $(event.target);
        if (target.is('ul')) {

        } else if (target.parents('.items-section').length > 0) {
            target = target.parents('.items-section').children('ul').first();
        } else {
            return;
        }
        dragged.remove();
        dragged.appendTo(target);
    }

    sectionContainer.on('dragenter', function (event) {
        event.preventDefault();
        event.stopPropagation();
    });
    sectionContainer.on('dragover', function (event) {
        event.preventDefault();
        event.stopPropagation();
    });

    function displayInputElement(event) {
        var clicked = $(event.target);
        clicked.removeClass('visible');
        clicked.siblings('input').first().addClass('visible');
    }

    function addNewItem(event) {
        var clicked = $(event.target),
            newItemText,
            newItem;
        if (event.keyCode !== 13) {
            return;
        }
        newItemText = clicked.val();
        templateItemAnchor
            .html(newItemText)
            .attr('href', urlTemplateString + newItemText);
        newItem = templateItem.clone();
        clicked
            .parents('.items-section')
            .children('ul')
            .append(newItem);
        clicked.val('');
        clicked.removeClass('visible');
        clicked.siblings('.add-btn').first().addClass('visible');
    }
};