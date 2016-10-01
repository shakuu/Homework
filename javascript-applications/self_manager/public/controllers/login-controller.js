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
                    const inputPassword = tbPassword.val();
                    const hashedPassword = cryptoTools.encrypt(inputPassword);
                    const user = {
                        username: tbUsername.val(),
                        passHash: hashedPassword
                    };

                    loginService.login(user)
                        .then((user) => {
                            toastr.success(`${user} logged in.`);
                        })
                        .catch((res) => {
                            toastr.error(res.responseText);
                        });
                });
            })
            .catch((error) => {
                toastr.error(error.responseText);
            });
    }

    return {
        main
    };
})();