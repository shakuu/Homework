const loginService = (() => {
    URLS = {
        LOGIN: 'api/users/auth'
    };

    function login(user) {
        return ajaxRequester.putJSON(URLS.LOGIN, user)
            .then((response) => {
                credentialManager.save(response);
                const user = response.username;
                return user;
            });
    }

    return {
        login
    };
})();