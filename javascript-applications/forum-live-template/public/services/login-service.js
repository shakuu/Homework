// TODO:
// Check URLS.
// Check response format.

const loginService = (() => {
    URLS = {
        GET: 'api/users',
        LOGIN: 'api/auth',
        REGISTER: 'api/users'
    };

    function login(user) {
        return ajaxRequester.putJSON(URLS.LOGIN, user)
            .then((response) => {
                // CHECK RESPONSE FORMAT
                // console.log(response);

                const user = response;
                credentialManager.save(user);

                const username = user.username;
                return username;
            });
    }

    function register(user) {
        return ajaxRequester.postJSON(URLS.REGISTER, user)
            .then((response) => {
                // CHECK RESPONSE FORMAT
                // console.log(response);

                const username = response.username;
                return username;
            });
    }

    function allUsers() {
        return ajaxRequester.get(URLS.GET);
    }

    return {
        login,
        register,
        allUsers
    };
})();