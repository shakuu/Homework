const loginController = (() => {
    function main(containerId) {
        const content = $(containerId);

        return handlebarsViewLoader.load('login')
            .then((view) => {
                const html = view();
                content.html(html);

                const loginForm = content.find('#login-form');
                return loginForm;
            })
            .then((loginForm) => {
                const tbUsername = loginForm.find('#tb-username');
                const tbPassword = loginForm.find('#tb-password');

                const btnLogin = loginForm.find('#btn-login');
                btnLogin.on('click', (ev) => {
                    const user = createUserObjectFromInput();
                    loginService.login(user)
                        .then((user) => {
                            toastr.success(`${user} logged in.`);
                        })
                        .then(() => {
                            window.location = '#/';
                        })
                        .catch((res) => {
                            toastr.error(res.responseText);
                        });
                });

                const btnRegister = loginForm.find('#btn-register');
                btnRegister.on('click', (ev) => {
                    const user = createUserObjectFromInput();
                    loginService.register(user)
                        .then((user) => {
                            toastr.success(`${user} registered.`);
                        })
                        .then(() => {
                            loginService.login(user);
                        })
                        .then(() => {
                            window.location = '#/';
                        })
                        .catch((res) => {
                            toastr.error(res.responseText);
                        });
                });

                function createUserObjectFromInput() {
                    const inputPassword = tbPassword.val();
                    const hashedPassword = cryptoTools.toFortyCharactersSHA1(inputPassword);
                    const user = {
                        username: tbUsername.val(),
                        authCode: hashedPassword
                    };

                    return user;
                }
            })
            .catch((error) => {
                toastr.error(error.responseText);
            });
    }

    function displayAllUsers(containerId) {
        const content = $(containerId);

        return Promise.all([
                handlebarsViewLoader.load('users'),
                loginService.allUsers()
            ])
            .then(([view, users]) => {
                const html = view(users.result);
                content.html(html);
            })
            .catch((err) => {
                toastr.error(err.responseText);
            });
    }

    function logout() {
        return loginService.logout()
            .then((res) => {
                credentialManager.remove()
                    .then((username) => {
                        toastr.success(`${username} has logged out.`);
                    })
                    .catch((err) => {
                        toastr.error(err.message);
                    });
            });
    }

    return {
        main,
        logout,
        displayAllUsers
    };
})();