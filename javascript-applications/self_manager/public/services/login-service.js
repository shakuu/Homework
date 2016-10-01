const loginService = (() => {
    URLS = {
        LOGIN: 'api/users/auth',
        REGISTER: 'api/users'
    };

    function login(user) {
        return ajaxRequester.putJSON(URLS.LOGIN, user)
            .then((response) => {
                const user = response.result;
                credentialManager.save(user);

                const username = user.username;
                return username;
            });
    }

    function register(user) {
        return ajaxRequester.postJSON(URLS.REGISTER, user)
            .then((response) => {
                const username = response.result.username;
                return username;
            });
    }

    return {
        login,
        register
    };
})();