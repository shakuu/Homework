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

    output.tabMenu.on('click', switchTabs)
    return output;
}

function switchTabs(event) {
    var clicked = $(event.target);

    if (clicked.hasClass('btn-add') || clicked.parents('.btn-add').length > 0) {
        return;
    }

    if (clicked.hasClass('tab')) {

    } else if (clicked.parents('.tab').length > 0) {
        clicked = clicked.parents('.tab').first();
    }

    console.log(clicked.data('tab-id'));
}

function initializeTabTemplate() {
    var output = {
        'idProvider': getId,
        'tabButton': null,
        'tabContent': null
    };
    output.tabButton = $('<a />').addClass('tab');
    output.tabContent = $('<div />').addClass('tab-content');
    return output;
}

function initializeButtonAdd() {
    var output = $('<a />')
        .addClass('tab')
        .addClass('btn-add')
        .html('New Tab');
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
        .data('tab-id', newTab.id)
        .html(options.tabName)
        .appendTo(controls.tabMenu);
    newTab.tabContent
        .data('tab-id', newTab.id)
        .appendTo(controls.tabContainer);
    return newTab;
}

function getId() {
    id += 1;
    return id;
}