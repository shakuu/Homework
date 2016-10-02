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
            })
            .then(() => {
                router.navigate('/home');
            });
    });

    router.on('/todos/filter', () => {
        const hash = window.location.hash;
        const queryParams = queryParamsHelper.getQueryParamsFromHash(hash);

        todosController.main(containerId)
            .then(() => {
                const queryParamsKeys = Object.keys(queryParams);
                if (queryParamsKeys.length === 0) {
                    return;
                }

                const predicate = (element) => {
                    const field = $(element).find(`.${queryParamsKeys[0]}`);
                    const isMatch = field.html() === queryParams[queryParamsKeys[0]];
                    return isMatch;
                };

                domTreeHelpers.showElementsWith('#content', '.todo', predicate);
            })
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
    
    router.on('/todos', () => {
        todosController.main(containerId)
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