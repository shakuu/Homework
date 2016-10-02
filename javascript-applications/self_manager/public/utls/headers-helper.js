const headersHelper = (() => {
    function addXAuthKeyHeader(headers = {}) {
        const loggedUser = credentialManager.isLogged();
        if (loggedUser) {
            const user = credentialManager.load();
            headers['x-auth-key'] = user.authKey;
        } else {
            throw new Error('Not logged in');
        }

        return headers;
    }

    return {
        addXAuthKeyHeader
    };
})();