jQuery.fn.listview = function (data) {

    let listSelector = $(this);
    let templateName = listSelector.attr('data-template');
    let source = $('#' + templateName).html();
    let template = Handlebars.compile(source);

    let outputHtml = '';
    for (let i = 0; i < data.length; i += 1) {
        outputHtml += template(data[i]);
    }

    listSelector.html(outputHtml);

    return listSelector;
};