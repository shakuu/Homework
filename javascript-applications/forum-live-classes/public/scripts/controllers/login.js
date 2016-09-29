const LoginController = (() => {
    class LoginController {
        constructor(templateService, dataService) {
            this.templateService = templateService;
            this.dataService = dataService;
        }

        start(containerId) {
            const that = this;

            const container = $(containerId);
            return this.templateService.get('login')
                .then((template) => {
                    const html = template();
                    container.html(html);
                    return html;
                })
                .then((html) => {
                    const btnLogin = container.find('#btn-login');
                    btnLogin.on('click', (ev) => {
                        const username = container.find('#tb-username');
                        const password = container.find('#tb-password');
                        const user = {
                            username: username.val(),
                            passHash: password.val()
                        };

                        that.dataService.userLogin(user)
                            .then((response) => {
                                console.log(response);
                            });
                    });
                });
        }
    }

    return LoginController;
})();

module.exports = LoginController;