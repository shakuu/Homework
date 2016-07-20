// Output -> glabal vars
// inputData -> array of objects, contains requested data
// inputDataOptions -> object, contains page info, number of pages, fields per page
var inputData,
    inputDataOptions;

// jsonP prefix=
// api request returns a function call with prefix=functionName
// and json with requested data as parameter.
function getdata(data) {
    // DELETE
    console.log(data);

    inputData = data[1];
    inputDataOptions = data[0];
}

function getDataFromApi(apiUrl) {
    $.ajax({
        url: apiUrl,
        // Tell jQuery we're expecting JSONP
        dataType: "jsonp",
    });
}
