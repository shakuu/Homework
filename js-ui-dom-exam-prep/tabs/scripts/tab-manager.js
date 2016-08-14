var id = 0,
    controls,
    btnAdd,
    tabTemplate;

$.fn.tabsControl = function () {
    var options = {
        'tabsListID': 'tabs-list',
        'tabsContainerID': 'tabs-container',
    };
    controls = initiazlizeContainers(options);
    btnAdd = initializeButtonAdd();
    tabTemplate = initializeTabTemplate();

    controls.tabMenu.append(btnAdd);
    $(this).append(controls.tabControlContainer);
    return $(this);
};

function initiazlizeContainers(options) {
    var container,
        output = {
            'tabControlContainer': $(),
            'tabMenu': $(),
            'tabContainer': $()
        };
    options.listID = options.listID ? options.listID : 'tabs-list';
    options.containerID = options.containerID ? options.containerID : 'tabs-container';
    options.container = options.container ? options.container : '#root';

    output.tabMenu = $('<ul />').attr('id', options.listID);
    output.tabContainer = $('<div />').attr('id', options.containerID);
    output.tabControlContainer = $('<div />')
        .addClass('tab-control-container')
        .append(output.tabMenu)
        .append(output.tabContainer);

    output.tabMenu.on('click', switchTabs);
    return output;
}

function switchTabs(event) {
    var clicked = $(event.target),
        clickedId,
        toRemove = false;

    if (clicked.hasClass('btn-add') || clicked.parents('.btn-add').length > 0) {
        return;
    }
    if (clicked.hasClass('btn-remove')) {
        toRemove = true;
    }

    if (clicked.hasClass('tab')) {

    } else if (clicked.parents('.tab').length > 0) {
        clicked = clicked.parents('.tab').first();
    } else {
        return;
    }

    clickedId = clicked.data('tab-id');
    console.log(clickedId);
    if (toRemove) {
        removeTabWithId(clickedId);
        clicked.remove();
    } else {
        displayTabWithId(clickedId);
    }
}

function removeTabWithId(id) {
    var allTabs = controls.tabContainer.children('.tab-content');
    for (var i = 0, len = allTabs.length; i < len; i += 1) {
        var current = $(allTabs[i]),
            currentId = current.data('tab-id');
        if (currentId === id) {
            current.remove();
        }
    }
}

function displayTabWithId(id) {
    var allTabs = controls.tabContainer.children('.tab-content');
    for (var i = 0, len = allTabs.length; i < len; i += 1) {
        var current = $(allTabs[i]),
            currentId = current.data('tab-id');
        if (currentId === id) {
            current.addClass('visible');
        } else {
            current.removeClass('visible');
        }
    }
}

function initializeTabTemplate() {
    var output = {
        'idProvider': getId,
        'tabButton': null,
        'removeButton': null,
        'tabName': null,
        'tabContent': null,
        'tabEditable': null
    };
    output.tabButton = $('<li />').addClass('tab');
    output.tabName = $('<strong />')
        .addClass('tab-name')
        .appendTo(output.tabButton);
    output.removeButton = $('<a />')
        .addClass('btn-remove')
        .html('X')
        .appendTo(output.tabButton);
    output.tabContent = $('<div />').addClass('tab-content');
    output.tabEditable = $('<div />')
        .addClass('user-input')
        .attr('contenteditable', 'true')
        .appendTo(output.tabContent);
    return output;
}

function initializeButtonAdd() {
    var output = $('<a />')
        .addClass('tab')
        .addClass('btn-add')
        .html('+');
    output.on('click', createNewTab);
    return output;
}

function createNewTab(options) {
    options.tabName = options.tabName ? options.tabName : 'new tab';

    var newTab = {
        'id': tabTemplate.idProvider(),
        'tabButton': tabTemplate.tabButton.clone(),
        'tabContent': tabTemplate.tabContent.clone()
    };
    newTab.tabButton
        .children('.tab-name')
        .first()
        .html(options.tabName);
    newTab.tabButton
        .data('tab-id', newTab.id)
        .appendTo(controls.tabMenu);
    newTab.tabContent
        .data('tab-id', newTab.id)
        .prepend(newTab.id)
        .appendTo(controls.tabContainer);
    // push Add Button right 
    // btnAdd.remove().appendTo(controls.tabMenu).on('click', createNewTab);
    return newTab;
}

function getId() {
    id += 1;
    return id;
}