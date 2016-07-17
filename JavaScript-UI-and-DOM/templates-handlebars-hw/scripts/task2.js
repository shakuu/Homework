function buildAnimals(data) {
    let source = $('#task2-table-template').html();
    let template = Handlebars.compile(source);

    checkAnimals(data);

    let output = template(data);

    $('section#output').html($('section#output').html() + output);
}

function checkAnimals(data) {
    for (let i in data.animals) {
        if (!data.animals[i].url) {
            data.animals[i] = {
                name: data.animals[i].name,
                url: '#'
            };
        }
    }
}