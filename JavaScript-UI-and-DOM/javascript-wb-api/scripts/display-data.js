function displayFooterInfo(footerInput) {
    // Object
    // page:1
    // pages:337
    // per_page:"50"
    // total:16844

    // DELETE
    console.log(footerInput);

    // let container = $('<div>')
    //     .addClass('footer-info');

    // for (let item in footerInput) {
    //     $('<div>')
    //         .text(`${item}: ${footerInput[item]}`)
    //         .appendTo(container);
    // }

    // $('#data footer')
    //     .html('')
    //     .append(container);

    let sourceTemplate = $('#footer-template').html();
    let template = Handlebars.compile(sourceTemplate);
    let outputHtml = template(footerInput);

    $('#data footer').html(outputHtml);
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

    let arrayInfo = {
        indeces: inputArrayOfObjects
    };

    console.log(arrayInfo.indec);

    // for (let i in arrayInfo) {
    //     let newItem = $('<div>')
    //         .addClass('item')
    //         .appendTo($('#data article#content'));

    //     $('<div>')
    //         .text(`id: ${arrayInfo[i].id}`)
    //         .appendTo(newItem);

    //     $('<div>')
    //         .text(`Name: ${arrayInfo[i].name}`)
    //         .appendTo(newItem);

    //     $('<div>')
    //         .text(`Note: ${arrayInfo[i].sourceNote}`)
    //         .appendTo(newItem);
    // }

    let sourceTemplate = $('#data-template').html();
    let template = Handlebars.compile(sourceTemplate);
    let outputHtml = template(arrayInfo);

    $('#data article#content').html(outputHtml);
}