const homeDataService = (() => {
    const URLS = {
        POST: 'post'
    };

    function loadAllPosts() {
        return ajaxRequester.get(URLS.POST);
    }

    return {
        loadAllPosts
    };
})();