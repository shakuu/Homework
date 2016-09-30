const userController = (() => {
    function home(contentId) {
        $(contentId).html('');
        if (userDataService.isLogged()) {
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
                const btnRegister = container.find('#btn-register');
                btnRegister.on('click', (ev) => {
                    const username = container.find('#tb-username');
                    const password = container.find('#tb-password');
                    const user = {
                        username: username.val(),
                        passHash: password.val()
                    };

                    userDataService.userRegister(user)
                        .then((data) => {
                            userDataService.userLogin(user)
                                .then(() => {
                                    return data;
                                });

                            window.location = '#/';
                            return data;
                        })
                        .catch((error) => {
                            toastr.error(error);
                        });
                });

                const btnLogin = container.find('#btn-login');
                btnLogin.on('click', (ev) => {
                    const username = container.find('#tb-username');
                    const password = container.find('#tb-password');
                    const user = {
                        username: username.val(),
                        passHash: password.val()
                    };

                    userDataService.userLogin(user)
                        .then((data) => {
                            window.location = '#/';
                            return data;
                        })
                        .then((data) => {
                            $(document.body).addClass('logged-in');
                            return data;
                        })
                        .then((data) => {
                            toastr.success(`Welcome back ${data.username}`);
                        })
                        .catch((error) => {
                            noty({text: 'test'});
                            toastr.error('Invalid username or password');
                        });
                });
            });
    }

    function allUsers(contentId) {
        const container = $(contentId);

        Promise.all([
            templates.get('all-users'),
            userDataService.allUsers()
        ])
            .then(([template, data]) => {
                const html = template(data.result);
                container.html(html);
                return [template, data.result];
            });
    }

    function logout() {
        userDataService.userLogout();
        window.location = '#/';
    }

    return {
        home,
        login,
        logout,
        allUsers
    };
})();