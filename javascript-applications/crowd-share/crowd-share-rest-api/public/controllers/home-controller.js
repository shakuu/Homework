const homeController = (() => {
    function main(containerId) {
        const content = $(containerId);

        return Promise.all([
            viewLoader.load('home'),
            viewLoader.load('home-item'),
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