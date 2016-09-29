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

    return {
        getAll,
        addNew
    };
})();