// Returns updated url
function changePageNumber(newPageNumber, currentRequestUrl) {
    // Return on no change
    if (currentRequestUrl.options.page === newPageNumber) {
        return newPageNumber;
    }

    // Validate new page numbers
    try {
        checkIfRequestedPageIsAvailable(newPageNumber);
    } catch (error) {
        console.log(error);

        // Return current page number in case validation fails.
        return currentRequestUrl.options.page;
    }

    return newPageNumber;
}

function checkIfRequestedPageIsAvailable(pageNumber) {
    let numberOfPagesAvailable = inputDataOptions.pages;

    if (+pageNumber < 1 || +numberOfPagesAvailable < +pageNumber) {
        throw Error(`page ${pageNumber} not available in source`);
    }
}