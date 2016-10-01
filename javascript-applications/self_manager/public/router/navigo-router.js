const appRouter = (() => {
    let containerId = '#content';
    const router = new Navigo(null, true);

    router.on(() => {
        router.navigate('/home');
    });

    router.notFound(() => {
        homeController.load(containerId);
    });

    function start(container) {
        containerId = container;
        router.resolve();
    }

    return {
        start
    };
})();