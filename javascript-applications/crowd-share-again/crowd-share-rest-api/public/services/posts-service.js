const postsService = (() => {
    const URLS = {
        GET: 'post',
        POST: 'post'
    };

    function getPosts(query) {
        return ajaxRequester.get(URLS.GET);
    }

    function createPost(post) {
        const headers = headersHelper.addXSessionKeyHeader();
        return ajaxRequester.postJSON(URLS.POST, post, headers);
    }

    return {
        getPosts,
        createPost
    };
})();