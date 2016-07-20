function attachTableEvent(tableId) {
    $(tableId).on('click', 'tr.data-row', handleOnClickRow);
}

function handleOnClickRow(event) {
    let clickedIso2CodeElement = [].slice.call($(event.currentTarget).children(), 0)
        .filter(child => {
            return $(child).hasClass('iso2Code');
        });

    let isoCode = $(clickedIso2CodeElement).children('p').first().html();

    // DELETE
    console.log(isoCode);

    // build new request URL for the country.
    currentRequestUrl = addCountryCodeToUrl(isoCode, currentRequestUrl);
}