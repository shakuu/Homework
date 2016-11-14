/* globals credentialManager */

const headersHelper = (() => {
    const HEADERS = {
        X_AUTH_KEY: 'x-auth-key'
    };

    function addXAuthKeyHeader(headers = {}) {
        const loggedUser = credentialManager.isLogged();
        if (loggedUser) {
            const user = credentialManager.load();
            headers[HEADERS.X_AUTH_KEY] = user.authKey;
        } else {
            throw new Error('Not logged in');
        }

        return headers;
    }

    return {
        addXAuthKeyHeader
    };
})();