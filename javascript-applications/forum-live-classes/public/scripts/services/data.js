const DataService = (() => {
    class DataService {
        constructor(SERVER_URL, requestsProvider) {
            this.URLS = SERVER_URL;

            this.requests = requestsProvider;
        }

        isUserLoggedIn() {
            return window.sessionStorage.USER_NAME && window.sessionStorage.AUTH_KEY;
        }

        loggedInUser() {
            let username = 'annonymous';
            if (this.isUserLoggedIn) {
                username = window.sessionStorage.USER_NAME;
            }

            return username;
        }

        userLogin(user) {
            const that = this;
            return this.requests.post(this.URLS.USERS, user)
                .then((response) => {
                    that._saveUser(response);
                    return response;
                });
        }

        _saveUser(user) {
            window.sessionStorage.setItem('USER_NAME', user.username);
            window.sessionStorage.setItem('AUTH_KEY', user.authKey);
        }
    }

    return DataService;
})();

module.exports = DataService;