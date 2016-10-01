const appRouter = ((containerId) => {
    const router = new Navigo(null, true);

    router.on(() => {
        router.navigate('/home');
    });

    router.on('/home', () => {
        homeController.load(containerId);
    });

    return router;
})();