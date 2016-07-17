function createTable(data) {
    // Step 1: build the template

    // Compile the template.
    let sourse = $('#table-template').html();
    let template = Handlebars.compile(sourse);

    // Create helper ( if needed )
    let counter = 0;
    Handlebars.registerHelper('index', function () {
        counter += 1;
        return counter;
    });

    // Populate the template
    let output = template(data);

    // Append to html
    $('#output').html(output);
}