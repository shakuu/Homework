const homeController = (() => {
    function load(containerId) {
        return Promise.all([
            viewsLoader.load('home'),
            homeDataService.loadAllPosts()
        ])
            .then(([view, data]) => {
                console.log(data);
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