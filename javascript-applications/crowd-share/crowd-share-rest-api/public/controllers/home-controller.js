const homeController = (() => {
    function load(containerId) {
        const content = $(containerId);

        return Promise.all([
            viewsLoader.load('home'),
            homeDataService.loadAllPosts()
        ])
            .then(([view, data]) => {
                const html = view();
                content.html(html);
            })
            .then(() => {
                toastr.success('yay!');
            })
            .catch((res) => {
                console.log(res);
                toastr.error(res.responseText);
            });
    }

    return {
        load
    };
})();