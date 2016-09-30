const usersService = (() => {
    const URLS = {
        USERS: 'api/users',
        AUTH: 'api/auth'
    };

    function allUsers() {
        let headers = {};
        if (isLoggedIn()) {
            headers = {
                'x-auth-key': window.localStorage.authKey
            };
        }

        return requester.get(URLS.USERS, headers);
    }

    function login(user) {
        return requester.putJSON(URLS.AUTH, user)
            .then((response) => {
                window.localStorage.setItem('username', response.result.username);
                window.localStorage.setItem('authKey', response.result.authKey);
                return response;
            });
    }

    function register(user) {
        return requester.postJSON(URLS.USERS, user);
    }

    function logout() {
        return new Promise((resolve, reject) => {
            window.localStorage.removeItem('username');
            window.localStorage.removeItem('authKey');
            resolve();
        });
    }

    function isLoggedIn() {
        const usernameEntryExists = window.localStorage.username ? true : false;
        const authKeyEntryExists = window.localStorage.authKey ? true : false;
        const isLoggedIn = usernameEntryExists && authKeyEntryExists;
        return isLoggedIn;
    }

    return {
        allUsers,
        register,
        login,
        logout,
        isLoggedIn
    };
})();