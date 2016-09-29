const router = (() => {
    const router = new Navigo(null, true);

    router.on('/login', () => {
        controllers.login('#content');
    });

    return router;
})();