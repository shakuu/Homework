// div - row
//     div - cell
//     div - cell
function buildTemplateBasedOnObject(object, tableId = '') {
    let table = $('<div>')
        .attr('id', tableId)
        .addClass('data-table')
        .html('\{\{#items\}\}');

    let row = $('<div>')
        .addClass('data-row');

    for (let item in object) {
        $('<div>')
            .addClass('data-cell')
            .html(`\{\{${item}\}\}`)
            .appendTo(row);
    }

    table
        .append(row)
        .html(table.html() + '\{\{/items\}\}');

    $('<script>')
        .attr('id', 'data-row-template')
        .attr('type', 'text/x-handlebars-template')
        .append(table)
        .appendTo($('body'));

    return $('#data-row-template');
}