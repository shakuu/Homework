const threadsDataService = (() => {

    const URLS = {
        ALL_THREADS: 'api/threads'
    };

    function getAll() {
        return request.get(URLS.ALL_THREADS);
    }

    function addNew(thread) {
        let authKey = '';
        if (window.localStorage.authKey) {
            authKey = window.localStorage.authKey;
        }

        const headers = {
            'x-authkey': authKey
        };

        return request.postJSON(URLS.ALL_THREADS, thread, headers);
    }

    function getById(id) {
        const url = URLS.ALL_THREADS + '/' + id;
        return request.get(url);
    }

    function addMessage(id, message) {
        let authKey = '';
        if (window.localStorage.authKey) {
            authKey = window.localStorage.authKey;
        }

        const headers = {
            'x-authkey': authKey
        };

        const url = `api/threads/${id}/messages`;
        return request.postJSON(url, message, headers);
    }

    return {
        getAll,
        addNew,
        getById,
        addMessage
    };
})();