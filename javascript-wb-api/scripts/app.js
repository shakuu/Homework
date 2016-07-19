function getdata(data) {
    console.log(data);
}

// prefix -> function to handle the data
var urlAPI = 'http://api.worldbank.org/indicators?format=jsonP&prefix=getdata';

$.ajax({
    url: urlAPI,

    // Tell jQuery we're expecting JSONP
    dataType: "jsonp",
});