function displayFooterInfo(footerInput) {
    // Object
    // page:1
    // pages:337
    // per_page:"50"
    // total:16844

    let data = { items: footerInput };

    let templateScript = buildTemplateBasedOnObject(footerInput);
    let sourceTemplate = $(templateScript).html();
    let template = Handlebars.compile(sourceTemplate);
    let outputHtml = template(data);

    $('#data footer').html(outputHtml);
    $(templateScript).remove();
}

function displayData(inputArrayOfObjects) {
    // Indeces
    // id
    // name
    // source ( object )
    // sourceNote:
    // sourceOrganization
    // topics: Array

    let data = { items: inputArrayOfObjects };

    let templateScript = buildTemplateBasedOnObject(inputArrayOfObjects[0]);
    let sourceTemplate = $(templateScript).html();
    let template = Handlebars.compile(sourceTemplate);
    let outputHtml = template(data);

    $(templateScript).remove();
    $('#data article#content').html(outputHtml);
}