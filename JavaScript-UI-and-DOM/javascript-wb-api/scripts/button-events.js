function initButtonEvents() {
    // Send request to the worldbank.org API and store the result
    $('#get-data').on('click', function () {
        let url = buildRequestUrl(currentRequestUrl);
        getDataFromApi(url);
    });

    // Display the footer info ( input [0] )
    $('#display-footer').on('click', function () {
        displayFooterInfo(inputDataOptions);
    });

    // Displpay input data.
    // Input data [1] contains an array of objects.
    $('#display-data').on('click', function () {
        displayData(inputData);
    });

    // DELETE
    $('#test-url-builder').on('click', function () {
        let optionsString = buildRequestUrl(currentRequestUrl);

        console.log(optionsString);
        console.log(currentRequestUrl);
    });
}