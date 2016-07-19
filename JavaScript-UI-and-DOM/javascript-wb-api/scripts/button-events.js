// Send request to the worldbank.org API and store the result
$('#get-data').on('click', function () {
    getDataFromApi(urlAPI);
});

// Display the footer info ( input [0] )
$('#display-footer').on('click', function () {
    displayFooterInfo(inputData[0]);
});

// Displpay input data.
// Input data [1] contains an array of objects.
$('#display-data').on('click', function () {
    displayData(inputData[1]);
});