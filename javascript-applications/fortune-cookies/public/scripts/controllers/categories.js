const categoriesController = (() => {
    function load(containerId) {
        const content = $(containerId);

        Promise.all([
            templatesService.loadTemplate('categories'),
            categoriesService.allCategories()
        ])
            .then(([template, categories]) => {
                const html = template(categories.result);
                content.html(html);
            });
    }

    return {
        load
    };
})();