const dataService = (() => {
    const URLS = {
        USERS: 'api/users'
    };

    function isLogged() {
        const usernameEntry = window.localStorage.username ? true : false;
        const authKeyEntry = window.localStorage.authKey ? true : false;
        return usernameEntry && authKeyEntry;
    }

    function userLogin(user) {
        return request.postJSON(URLS.USERS, user)
            .then((response) => {
                window.localStorage.setItem('username', response.username);
                window.localStorage.setItem('authKey', response.authKey);
                return response;
            });
    }

    function userLogout() {
        window.localStorage.removeItem('username');
        window.localStorage.removeItem('authKey');
    }

    return {
        isLogged,
        userLogin,
        userLogout
    };
})();