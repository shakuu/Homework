const cookiesService = (() => {
    const URL = 'api/cookies';

    function allCookies() {
        return requester.get(URL);
    }

    return {
        allCookies
    };
})();