const RequestProvider = (() => {
    class RequestsProvider {
        get(url) {
            return new Promise((resolve, reject) => {
                $.ajax({
                    url: url,
                    method: 'GET'
                })
                    .done(resolve)
                    .fail(reject);
            });
        }

        post(url, data) {

        }

        put(url, data) {

        }
    }

    return RequestsProvider;
})();

module.exports = RequestProvider;