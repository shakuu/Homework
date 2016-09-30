const router = ((containerId) => {
    const router = new Navigo(null, true);

    router.on('/home', () => {

    });

    router.on(() => {
        router.navigate('/home');
    });

    router.notFound(() => {
        router.navigate('/home');
    });

    return router;
})('#content');