const appRouter = ((containerId) => {
    const router = new Navigo(null, true);

    router.on(() => {
        router.navigate('/home');
    });

    router.notFound(()=>{
        router.navigate('/home');
    });

    router.on('/home', () => {
        homeController.main(containerId);
    });

    router.on('/login', () => {
        usersController.login(containerId)
    });

    return router;
})('#content');