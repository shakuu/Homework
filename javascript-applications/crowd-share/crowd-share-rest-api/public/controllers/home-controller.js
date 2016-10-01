const homeController = (() => {
    function main(containerId) {
        const content = $(containerId);

        return Promise.all([
            viewsLoader.load('home'),
            viewsLoader.load('home-item'),
            homeDataService.loadAllPosts()
        ])
            .then(([homeView, itemView, data]) => {
                const compiledData = itemView(data);
                const generatedHtml = homeView(compiledData);
                content.html(generatedHtml);
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
        main
    };
})();