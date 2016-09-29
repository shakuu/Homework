const request = (() => {
    function get(url) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: url,
                method: 'GET'
            })
                .done(resolve)
                .fail(reject);
        });
    }

    function postJSON(url, json, header) {
        header = header || {};
        return new Promise((resolve, reject) => {
            $.ajax({
                url: url,
                method: 'POST',
                contentType: 'application/json',
                headers: header,
                data: JSON.stringify(json)
            })
                .done(resolve)
                .fail(reject);
        });
    }

    function putJSON(url, json) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: url,
                method: 'PUT',
                contentType: 'application/json',
                data: JSON.stringify(json)
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