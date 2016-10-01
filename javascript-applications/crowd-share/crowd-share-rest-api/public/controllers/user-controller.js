const usersController = (() => {
    function login(containerId) {
        const content = $(containerId);

        return viewsLoader.load('login')
            .then((view) => {
                const html = view();
                content.html(html);
            })
            .then(() => [
                // events
            ])
            .catch((error) => {
                toastr.error(error.responseText);
            });
    }

    function logout() {

    }

    return {
        login,
        logout
    };
})();