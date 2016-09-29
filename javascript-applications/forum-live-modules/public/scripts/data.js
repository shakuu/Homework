const dataService = (() => {
    const URLS = {
        USERS: 'api/users'
    };

    function isLogged() {
        return true;
    }

    function userLogin(user) {
        return request.postJSON(URLS.USERS, user);
    }

    return {
        isLogged,
        userLogin
    };
})();