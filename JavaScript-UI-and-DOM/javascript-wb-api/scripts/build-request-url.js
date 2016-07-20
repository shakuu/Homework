// countries
// regions
// indicators

// var urlAPI = 'http://api.worldbank.org/countries?page=1&format=jsonP&prefix=getdata';
// 1. Base URL: http://api.worldbank.org
// 2. Request: ex. /counries 
// 3. Options: ex ?page=1
// 4. Prefix MUST HAVE !: ex.  &prefix=(function name) 

var currentRequestUrl = {
    base: '',
    request: [],
    options: {
        page: 0,
        format: '',
        prefix: ''
    }
};

var urlRequestOptionsTemplate = {
    page: 1,
    format: 'jsonP',
    prefix: 'getdata'
};

function buildRequestUrl(objUrl) {
    request = buildRequest(objUrl.request);
    options = buildOptions(objUrl.options);

    return `${objUrl.base}${request}${options}`;
}

// Returns a string containing the data request in the requiered format.
function buildRequest(request) {
    let output = '';

    for (const item in request) {
        output += `/${request[item]}`;
    }

    return output;
}

// Returns a string containing options in the required format.
function buildOptions(options) {
    let output = '?';

    for (const item in options) {
        output += `${item}=${options[item]}&`;
    }

    return output;
}

// Initialize url object with default values on window.load.
function initializeDefaultRequestURLObject() {
    const baseUrl = 'http://api.worldbank.org';

    let output = {
        base: baseUrl,
        request: ['countries'],
        options: {
            page: 1,
            format: 'jsonP',
            prefix: 'getdata'
        }
    };

    return output;
}