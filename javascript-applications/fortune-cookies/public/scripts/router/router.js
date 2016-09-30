const router = ((containerId) => {
    const router = new Navigo(null, true);

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