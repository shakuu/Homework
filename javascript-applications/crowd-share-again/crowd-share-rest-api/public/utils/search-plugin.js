const searchPlugin = (() => {
    function createFilter(containerId) {
        const content = $(containerId);
        return loadView(containerId)
            .then(() => {
                // filter dom elements
            });
    }

    function createQuery(containerId) {
        const content = $(containerId);
        return loadView(containerId)
            .then(() => {
                // attach query params
            });
    }

    function loadView(containerId) {
        const content = $(containerId);
        return handlebarsViewLoader.load('search-plugin')
            .then((view) => {
                const html = view();
                content.html(html);
            });
    }

    return {
        createFilter,
        createQuery
    };
})();