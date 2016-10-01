const ajaxRequester = (() => {
    function get(url, headers = {}) {
        return new Promise((resolve, reject) => {
            $.ajax({
                url: url,
                contentType: 'application/json',
                headers: headers
            })
                .done(resolve)
                .fail(reject);
        });
    }

    return {
        get
    };
})();