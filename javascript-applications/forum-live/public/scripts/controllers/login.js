const LoginController = (() => {
    class LoginController {
        constructor(templateService, dataService) {
            this.templateService = templateService;
            this.dataService = dataService;
        }

        start(containerId) {
            const container = $(containerId);
            return this.templateService.get('login')
                .then((template) => {
                    const html = template();
                    container.html(html);
                    return html;
                })
                .then((html) => {
                    // Attach events
                });
        }
    }

    return LoginController;
})();

module.exports = LoginController;