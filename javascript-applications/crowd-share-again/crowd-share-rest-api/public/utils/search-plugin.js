const searchPlugin = (() => {
    function createFilter(container, selector) {
        const content = $(container);
        if (content.length === 0) {
            return;
        }

        const elements = content.find(selector);
        if (elements.length === 0) {
            return;
        }

        return loadView(container)
            .then(() => {
                // filter dom elements
            });
    }

    function createQuery(container, selector) {
        const content = $(container);
        if (content.length === 0) {
            return;
        }

        const elements = content.find(selector);
        if (elements.length === 0) {
            return;
        }

        return loadView(container)
            .then(() => {
                // attach query params
            });
    }

    function loadView(containerId) {
        const content = $(containerId);
        return handlebarsViewLoader.load('search-plugin')
            .then((view) => {
                const html = view();
                content.prepend(html);
            });
    }

    return {
        createFilter,
        createQuery
    };
})();