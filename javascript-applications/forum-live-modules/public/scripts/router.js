const router = ((contentId) => {
    const router = new Navigo(null, true);

    router.on('/login', () => {
        controllers.login(contentId);
    });

    router.on('/', () => {
        controllers.home(contentId);
    });

    return router;
})('#content');