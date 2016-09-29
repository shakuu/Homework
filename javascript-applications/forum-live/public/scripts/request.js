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

    return {
        get
    };
})();