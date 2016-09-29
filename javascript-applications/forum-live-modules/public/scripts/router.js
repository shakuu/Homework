const router = ((contentId) => {
    const router = new Navigo(null, true);

    router.on('/logout', () => {
        userController.logout();
    });

    router.on('/login', () => {
        userController.login(contentId);
    });

    router.on('/users', () => {
        userController.allUsers(contentId);
    });

    router.on('/messages/:id', (params) => {
        threadsController.addMessageToThreadWith(contentId, params.id)
            .then(() => {
                window.location = '#/threads/' + params.id;
            });
    });

    router.on('/threads/add', () => {
        threadsController.addThread(contentId);
    });

    router.on('/threads/:id', (params) => {
        const currentHash = window.location.hash;
        threadsController.getThreadMessages(contentId, params.id);
    });

    router.on('/threads', () => {
        threadsController.allThreads(contentId);
    });

    router.on('/', () => {
        userController.home(contentId);
    });

    return router;
})('#content');