$.fn.tabs = function () {
    var root = $(this),
        allTabItems,
        active;

    root.addClass('tabs-container');
    
    allTabItems = root.children('.tab-item');
    allTabItems.children('.tab-item-content').hide();

    active = allTabItems.eq(0);
    active.addClass('current');
    active.children('.tab-item-content').show();

    root.on('click', '.tab-item-title', setActiveTab);

    function setActiveTab(event) {
        active.removeClass('current');
        active.children('.tab-item-content').hide();

        active = $(event.target).parents('.tab-item').first();

        active.addClass('current');
        active.children('.tab-item-content').show();
    }

    return $(this);
};