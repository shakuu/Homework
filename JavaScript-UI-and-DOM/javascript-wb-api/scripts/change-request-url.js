// helper to keep track of previous url pages options
var previousPagesStack = [];

// Returns updated url string with new page number
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

// Add a country code to the request stack if it matches the country code constraints ISO2/ ISO3
function addCountryCodeToUrl(isoCode, currentRequestUrl) {
    try {
        validateIsoCode(isoCode);
    } catch (error) {
        console.log(error);
    }

    previousPagesStack.push(isoCode);
    currentRequestUrl.request.push(isoCode);
    currentRequestUrl.options.page = changePageNumber(1, currentRequestUrl);

    return currentRequestUrl;
}

function validateIsoCode(isoCode) {
    if (!isoCode) {
        throw Error('input must have value');
    }

    if (typeof isoCode !== 'string') {
        throw Error('input must be a string');
    }

    if (isoCode.length < 2 || 3 < isoCode.length) {
        throw Error('input must be 2 or 3 characters long');
    }
}

// Request stack must have 2 elements, 
// if it does than the 2nd element is a country code,
// pop the element off the stack.
function removeCountryCodeFromUrl(currentRequestUrl) {
    try {
        checkRequestStackLength(2, 2);
    } catch (error) {
        console.log(error);
    }

    currentRequestUrl.request.pop();
    currentRequestUrl.options.page = changePageNumber(previousPagesStack.pop(), currentRequestUrl);

    return currentRequestUrl;
}

function checkRequestStackLength(requestStack, minimumLength, maximumLength) {
    if (requestStack.length < minimumLength || maximumLength < requestStack.length) {
        throw Error(`Requst stack must have between ${minimumLength} and ${maximumLength} elements to be eligible for this operation`);
    }
}