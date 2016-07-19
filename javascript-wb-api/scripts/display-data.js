function displayFooterInfo(footerInput) {
    // Object
    // page:1
    // pages:337
    // per_page:"50"
    // total:16844

    // DELETE
    console.log(footerInput);

    let container = $('<div>')
        .addClass('footer-info');

    for (let item in footerInput) {
        $('<div>')
            .text(`${item}: ${footerInput[item]}`)
            .appendTo(container);
    }

    $('#data footer')
        .html('')
        .append(container);
}

function displayData(inputArrayOfObjects) {
    // Indeces
    // id
    // name
    // source ( object )
    // sourceNote:
    // sourceOrganization
    // topics: Array

    // DELETE
    console.log(inputArrayOfObjects);

    let arrayInfo = [].slice.call(inputArrayOfObjects, 0);

    for (let i in arrayInfo) {
        let newItem = $('<div>')
            .addClass('item')
            .appendTo($('#data article#content'));

        $('<div>')
            .text(`id: ${arrayInfo[i].id}`)
            .appendTo(newItem);

        $('<div>')
            .text(`Name: ${arrayInfo[i].name}`)
            .appendTo(newItem);

        $('<div>')
            .text(`Note: ${arrayInfo[i].sourceNote}`)
            .appendTo(newItem);
    }
}