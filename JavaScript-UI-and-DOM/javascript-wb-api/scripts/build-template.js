// div - row
//     div - cell
//     div - cell

// Build Handlebars template for a table  with rows of items.
function buildTemplateTable(object, tableId = '') {
    let newScriptId = 'data-table-template';

    let table = $('<div>')
        .attr('id', tableId)
        .addClass('data-table')

    let headerRow = $('<div>')
        .addClass('header-row');

    let row = $('<div>')
        .addClass('data-row');

    for (let item in object) {
        $('<div>')
            .addClass('header-cell')
            .html(`${item}`)
            .appendTo(headerRow);

        $('<div>')
            .addClass('data-cell')
            .html(`\{\{${item}\}\}`)
            .appendTo(row);
    }

    table
        .append(headerRow)
        .html(table.html() + '\{\{#items\}\}')
        .append(row)
        .html(table.html() + '\{\{/items\}\}');

    $('<script>')
        .attr('id', 'data-table-template')
        .attr('type', 'text/x-handlebars-template')
        .append(table)
        .appendTo($('body'));

    return $('#data-table-template');
}

// Build Handlebars Template for a single item.
function buildTemplateSingleRow(object, rowId = '') {

    let row = $('<div>')
        .addClass('data-row')
        .html('\{\{#items\}\}');

    for (let item in object) {
        $('<div>')
            .addClass('data-cell')
            .html(`\{\{${item}\}\}`)
            .appendTo(row);
    }

    row.html(row.html() + '\{\{/items\}\}');

    $('<script>')
        .attr('id', 'data-row-template')
        .attr('type', 'text/x-handlebars-template')
        .append(row)
        .appendTo($('body'));

    return $('#data-row-template');
}