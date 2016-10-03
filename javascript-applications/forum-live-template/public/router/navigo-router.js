const appRouter = (() => {
    let containerId = '#content';
    const router = new Navigo(null, true);

    router.on('/home', () => {
        homeController.main(containerId);
        navbarController.displayControls();
    });

    router.on('/login', () => {
        loginController.main(containerId)
            .then(() => {
                navbarController.displayControls();
            });
    });

    router.on('/logout', () => {
        loginController.logout()
            .then(() => {
                navbarController.displayControls();
            });
    });

    router.on('/users', () => {
        loginController.displayAllUsers(containerId)
            .then(() => {
                pagination.paginate(containerId, '.user', 5);
            })
            .then(() => {
                navbarController.displayControls();
            });
    });

    router.on(() => {
        router.navigate('/home');
    });

    router.notFound(() => {
        router.navigate('/home');
    });

    function start(container) {
        containerId = container;
        router.resolve();
    }

    return {
        start
    };
})();