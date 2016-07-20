// div - table
//      div - row
//           div - cell
//           div - cell

// Build Handlebars template for a table  with rows of items.
function buildTemplateTable(object, tableId = 'data-table-output') {
    let newScriptId = 'data-table-template';

    let table = $('<table>')
        .attr('id', tableId)
        .addClass('data-table')
        .addClass('display')
        .addClass('compact')
        .append($('<thead>'))
        .append($('<tfoot>'))
        .append($('<tbody>').html('\{\{#items\}\}'));

    let headerRow = $('<tr>')
        .addClass('header-row');

    let row = $('<tr>')
        .addClass('data-row');

    let cellWidth = Math.floor((100 / Object.keys(object).length) - 2);

    for (let item in object) {
        $('<th>')
            .addClass('header-cell')
            .html(`<p>${item}</p>`)
            .appendTo(headerRow);

        $('<td>')
            .addClass('data-cell')
            .addClass(`${item}`)
            .html(`<p>\{\{${item}\}\}</p>`)
            .appendTo(row);
    }

    table.children('thead')
        .first()
        .append(headerRow)
        .parent()
        .children('tbody')
        .first()
        .append(row)
        .append('\{\{/items\}\}');

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

    let cellWidth = Math.floor((100 / Object.keys(object).length) - 2);

    for (let item in object) {
        $('<div>')
            .addClass('data-cell')
            .html(`<p>\{\{${item}\}\}</p>`)
            .css({ 'width': cellWidth + '%' })
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