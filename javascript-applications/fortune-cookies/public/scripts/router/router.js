const router = ((containerId) => {
    const router = new Navigo(null, true);

    router.on('/share', () => {
        shareController.load(containerId);
    });

    router.on('/my-cookie', () => {
        usersController.myCookie(containerId);
    });

    router.on('/users', () => {
        usersController.displayAll(containerId);
    });

    router.on('/login', () => {
        usersController.load(containerId);
    });

    router.on('/logout', () => {
        usersController.logout();
        window.location = '#/';
    });

    router.on('/categories', () => {
        categoriesController.load(containerId);
    });

    router.on('/home/:type/:id', (params) => {
        const cookie = {
            type: params.type,
            id: params.id
        };

        usersController.like(cookie);
        window.location = '#/';
    });

    router.on('/home', () => {
        const hash = window.location.hash;
        const params = getQueryParams(hash);
        homeController.load(containerId, params);
    });

    router.on(() => {
        router.navigate('/home');
    });

    router.notFound(() => {
        router.navigate('/home');
    });

    return router;

    function getQueryParams(hash) {
        hash = String(hash);

        let params = {};
        if (hash.indexOf('?') < 0) {
            return params;
        }

        const inputParams = hash.split('?')[1].split('&');
        inputParams.forEach(param => {
            const split = param.split('=');
            params[split[0]] = split[1];
        });

        return params;
    }
})('#content');