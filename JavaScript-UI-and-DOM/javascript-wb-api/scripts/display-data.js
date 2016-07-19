function displayFooterInfo(footerInput) {

    let data = { items: footerInput };

    let templateScript = buildTemplateSingleRow(footerInput);
    let sourceTemplate = $(templateScript).html();
    let template = Handlebars.compile(sourceTemplate);
    let outputHtml = template(data);

    $('#data footer').html(outputHtml);
    $(templateScript).remove();
}

function displayData(inputArrayOfObjects) {

    let data = { items: inputArrayOfObjects };

    let templateScript = buildTemplateTable(inputArrayOfObjects[0]);
    let sourceTemplate = $(templateScript).html();
    let template = Handlebars.compile(sourceTemplate);
    let outputHtml = template(data);

    $('#data article#content').html(outputHtml);
    $(templateScript).remove();

    $('#data-table-output').DataTable();
}