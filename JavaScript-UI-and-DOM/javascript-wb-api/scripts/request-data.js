// prefix -> function to handle the data

var urlAPI = 'http://api.worldbank.org/region?page=1&format=jsonP&prefix=getdata&';
var inputData;

function getdata(data) {
    console.log(data);
    inputData = data;
}

function getDataFromApi(apiUrl) {
    $.ajax({
        url: apiUrl,

        // Tell jQuery we're expecting JSONP
        dataType: "jsonp",
    });
}
