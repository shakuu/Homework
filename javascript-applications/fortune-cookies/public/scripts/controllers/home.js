const homeController = (() => {
    function load(containerId) {
        const container = $(containerId);

        Promise.all([
            templatesService.loadTemplate('home'),
            cookiesService.allCookies()
        ])
            .then(([template, cookies]) => {
                console.log(cookies);
            });
    }

    return {
        load
    };
})();