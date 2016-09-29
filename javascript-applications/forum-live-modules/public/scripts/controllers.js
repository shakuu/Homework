const controllers = (() => {
    function home(contentId) {
        $(contentId).html('');
        if (dataService.isLogged()) {
            $(document.body).addClass('logged-in');
        } else {
            $(document.body).removeClass('logged-in');
        }
    }

    function login(contentId) {
        const container = $(contentId);
        return templates.get('login')
            .then((template) => {
                const html = template();
                container.html(html);
            })
            .then(() => {
                const btnLogin = container.find('#btn-login');
                btnLogin.on('click', (ev) => {
                    const username = container.find('#tb-username');
                    const password = container.find('#tb-password');
                    const user = {
                        username: username.val(),
                        passHash: password.val()
                    };

                    dataService.userLogin(user)
                        .then((data) => {
                            window.location = '#/';
                            return data;
                        })
                        .then((data) => {
                            $(document.body).addClass('logged-in');
                            return data;
                        })
                        .then(console.log)
                        .catch(console.log);
                });
            });
    }

    function logout() {
        dataService.userLogout();
        window.location = '#/';
    }

    return {
        home,
        login,
        logout
    };
})();