function buildAnimals(data) {
    let source = $('#task2-table-template').html();
    let template = Handlebars.compile(source);

    let output = template(data);

    $('section#output').html($('section#output').html() + output);
}