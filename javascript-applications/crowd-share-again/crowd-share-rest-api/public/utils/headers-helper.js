const headersHelper = (() => {
    const HEADERS = {
        X_AUTH_KEY: 'x-auth-key',
        X_SessionKey: 'X-SessionKey'
    };

    function addXAuthKeyHeader(headers = {}) {
        const loggedUser = credentialManager.isLogged();
        if (loggedUser) {
            const user = credentialManager.load();
            headers[HEADERS.X_AUTH_KEY] = user.sessionKey;
        } else {
            throw new Error('Not logged in');
        }

        return headers;
    }

    function addXSessionKeyHeader(headers = {}) {
        const loggedUser = credentialManager.isLogged();
        if (loggedUser) {
            const user = credentialManager.load();
            headers[HEADERS.X_SessionKey] = user.sessionKey;
        } else {
            throw new Error('Not logged in');
        }

        return headers;
    }

    return {
        addXAuthKeyHeader
    };
})();