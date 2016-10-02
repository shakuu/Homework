const appRouter = (() => {
    let containerId = '#content';
    const router = new Navigo(null, true);

    router.on(() => {
        router.navigate('/home');
    });

    router.notFound(() => {
        router.navigate('/home');
    });

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
            })
            .then(() => {
                router.navigate('/home');
            });
    });

    router.on('/todos', () => {
        todosController.main(containerId)
            .then(() => {
                navbarController.displayControls();
            });
    });

    router.on('/todos/:todoId/:state', (params) => {
        const id = params.todoId;
        const update = {
            state: params.state
        };

        todosController.updateTodo(id, update)
            .then(() => {
                navbarController.displayControls();
            });
    });

    router.on('/events', () => {
        eventsController.main(containerId)
            .then(() => {
                navbarController.displayControls();
            });
    });

    function start(container) {
        containerId = container;
        router.resolve();
    }

    return {
        start
    };
})();