const ajaxRequester = (() => {
    function get(url, headers = {}) {
        url = encodeURI(url);
        return new Promise((resolve, reject) => {
            $.ajax({
                    url: url,
                    method: 'GET',
                    contentType: 'application/json',
                    headers: headers
                })
                .done(resolve)
                .fail(reject);
        });
    }

    function postJSON(url, json, headers = {}) {
        url = encodeURI(url);        
        return new Promise((resolve, reject) => {
            $.ajax({
                    url: url,
                    method: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify(json),
                    headers: headers
                })
                .done(resolve)
                .fail(reject);
        });
    }

    function putJSON(url, json, headers = {}) {
        url = encodeURI(url);        
        return new Promise((resolve, reject) => {
            $.ajax({
                    url: url,
                    method: 'PUT',
                    contentType: 'application/json',
                    data: JSON.stringify(json),
                    headers: headers
                })
                .done(resolve)
                .fail(reject);
        });
    }

    return {
        get,
        postJSON,
        putJSON
    };
})();