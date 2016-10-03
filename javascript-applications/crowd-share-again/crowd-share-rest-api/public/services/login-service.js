// TODO:
// Check URLS.
// Check response format.

const loginService = (() => {
    URLS = {
        GET: 'users',
        LOGIN: 'auth',
        REGISTER: 'user',
        LOGOUT: 'user'
    };

    function login(user) {
        return ajaxRequester.postJSON(URLS.LOGIN, user)
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
        console.log(user.authCode.length);
        return ajaxRequester.postJSON(URLS.REGISTER, user)
            .then((response) => {
                // CHECK RESPONSE FORMAT
                // console.log(response);

                // const username = response.username;
                return response;
            });
    }

    function logout() {
        const headers = headersHelper.addXSessionKeyHeader();
        return ajaxRequester.putJSON(URLS.LOGOUT, {}, headers);
    }

    function allUsers() {
        return ajaxRequester.get(URLS.GET);
    }

    return {
        login,
        logout,
        register,
        allUsers
    };
})();