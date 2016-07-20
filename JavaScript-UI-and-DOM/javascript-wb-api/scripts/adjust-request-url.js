// Returns updated url
function changePageNumber(targetPage, options) {
    // Return on no change
    if (currentRequestUrl.options.page === targetPage) {
        return;
    }

    // Validate new page numbers
    try {
        checkIfRequestedPageIsAvailable(targetPage);
    } catch (error) {
        console.log(error);
    }


}

function checkIfRequestedPageIsAvailable(pageNumber) {
    let numberOfPagesAvailable = +inputDataOptions.pages;

    if (+pageNumber < 1 || numberOfPagesAvailable < +pageNumber) {
        throw Error(`page ${pageNumber} not available in source`);
    }
}