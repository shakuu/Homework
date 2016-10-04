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
                const tbSearchPlugin = content.find('#tb-search-plguin');
                const query = {
                    pattern: tbSearchPlugin.val()
                };

                const currentHash = window.location.hash;
                const hashWithQuery = queryParamsHelper.addParamsToHash(currentHash, query);

                window.location = hashWithQuery;
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