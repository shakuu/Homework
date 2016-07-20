// var urlAPI = 'http://api.worldbank.org/countries?page=1&format=jsonP&prefix=getdata';
// 1. Base URL: http://api.worldbank.org
// 2. Request: ex. /counries 
// 3. Options: ex ?page=1
// 4. Prefix MUST HAVE !: ex.  &prefix=(function name) 

// countries
// region
// indicators
const baseUrl = 'http://api.worldbank.org';

function buildRequestUrl(request = '', options = null) {

    options = buildOptions(options);

    return `${baseUrl}${request}${options}`;
}

function buildRequest() {

}

function buildOptions(options) {
    if (!options) {
        options = {
            page: 1,
            format: 'jsonP',
            func: 'getdata'
        };
    }

    let output = '?';
    for (const item in options) {
        output += `${item}=${options[item]}&`;
    }
    return output;
}