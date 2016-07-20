// var urlAPI = 'http://api.worldbank.org/countries?page=1&format=jsonP&prefix=getdata';
// 1. Base URL: http://api.worldbank.org
// 2. Request: ex. /counries 
// 3. Options: ex ?page=1
// 4. Prefix MUST HAVE !: ex.  &prefix=(function name) 

// countries
// regions
// indicators

var currentRequestUrl = {
    base: null,
    request: null,
    options: null
};

var urlRequestOptionsTemplate = {
    page: 1,
    format: 'jsonP',
    prefix: 'getdata'
};

function buildRequestUrl(base = null, request = null, options = null) {
    const baseUrl = 'http://api.worldbank.org';

    if (!base) { base = baseUrl; }

    currentRequestUrl.base = base;

    request = buildRequest(request);
    options = buildOptions(options);

    return `${base}${request}${options}`;
}

function buildRequest(request) {
    if (!request) {
        request = [];
        request[0] = 'regions';
    }

    currentRequestUrl.request = request;

    let output = '';
    for (const item in request) {
        output += `/${request[item]}`;
    }
    return output;
}

function buildOptions(options) {
    if (!options) {
        options = {
            page: 1,
            format: 'jsonP',
            prefix: 'getdata'
        };
    }

    currentRequestUrl.options = options;

    let output = '?';
    for (const item in options) {
        output += `${item}=${options[item]}&`;
    }
    return output;
}