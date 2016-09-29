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
            return new Promise((resolve, reject) => {
                $.ajax({
                    method: 'POST',
                    url: url,
                    data: JSON.stringify(data),
                    contentType: 'application/json'
                })
                    .done(resolve)
                    .fail(reject);
            });
        }

        put(url, data) {

        }
    }

    return RequestsProvider;
})();

module.exports = RequestProvider;