const homeController = (() => {
    function load(containerId, params) {
        const container = $(containerId);

        Promise.all([
            templatesService.loadTemplate('home'),
            cookiesService.allCookies()
        ])
            .then(([template, data]) => {
                let cookies = data.result;
                if (params.sortby) {
                    const sortby = params.sortby;
                    cookies = cookies.sort((a, b) => {
                        if (a[sortby] > b[sortby]) {
                            return -1;
                        }

                        if (a[sortby] < b[sortby]) {
                            return 1;
                        }

                        if (a[sortby] === b[sortby]) {
                            return 0;
                        }
                    });
                }

                return [template, cookies];
            })
            .then(([template, cookies]) => {
                if (params.category) {
                    const category = params.category;
                    cookies = cookies.filter(cookie => {
                        return cookie.category === category;
                    });
                }

                if (params.userId) {
                    const userId = params.userId;
                    cookies = cookies.filter(cookie => {
                        return cookie.userId === userId;
                    });
                }

                return [template, cookies];
            })
            .then(([template, cookies]) => {
                const html = template(cookies);
                container.html(html);
            });
    }

    return {
        load
    };
})();