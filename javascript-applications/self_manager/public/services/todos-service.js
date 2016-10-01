const todosService = (() => {
    const URLS = {
        GET: 'api/todos'
    };

    function getAllTodos() {
        let headers = {};
        const loggedUser = credentialManager.isLogged();
        if (loggedUser) {
            const user = credentialManager.load();
            headers = {
                'x-auth-key': user.authKey
            };
        } else {
            throw new Error('Not logged in');
        }

        return ajaxRequester.get(URLS.GET, headers);
    }

    return {
        getAllTodos
    };
})();