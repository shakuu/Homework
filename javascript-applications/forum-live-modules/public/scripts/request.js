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

    function postJSON(url, json) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: url,
                method: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(json)
            })
                .done(resolve)
                .fail(reject);
        });
    }

    return {
        get,
        postJSON
    };
})();