const userDataService = (() => {
    const URLS = {
        REGISTER_USER: 'api/users',
        LOGIN_USER: 'api/auth'
    };

    function isLogged() {
        const usernameEntry = window.localStorage.username ? true : false;
        const authKeyEntry = window.localStorage.authKey ? true : false;
        return usernameEntry && authKeyEntry;
    }

    function userLogin(user) {
        return request.putJSON(URLS.LOGIN_USER, user)
            .then((response) => {
                window.localStorage.setItem('username', response.username);
                window.localStorage.setItem('authKey', response.authKey);
                return response;
            });
    }

    function userRegister(user) {
        return request.postJSON(URLS.REGISTER_USER, user)
            .then((response) => {
                return response;
            });
    }

    function userLogout() {
        window.localStorage.removeItem('username');
        window.localStorage.removeItem('authKey');
    }

    function allUsers() {
        return request.get(URLS.REGISTER_USER);
    }

    return {
        isLogged,
        userRegister,
        userLogin,
        userLogout,
        allUsers
    };
})();