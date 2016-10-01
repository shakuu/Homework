const eventsService = (() => {
    const URLS = {
        GET: 'api/events'
    };

    function getAllEvents() {
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
        getAllEvents
    };
})();