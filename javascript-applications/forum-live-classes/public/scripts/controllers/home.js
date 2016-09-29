const HomeController = (() => {
    class HomeController {
        constructor() {

        }

        start(containerId) {
            $(containerId).html('');
        }
    }

    return HomeController;
})();

module.exports = HomeController;