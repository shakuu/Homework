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
                const btnSearchPlugin = content.find('#btn-search-plugin');
                btnSearchPlugin.on('click', (ev) => {
                    const tbSearchPlugin = content.find('#tb-search-plugin');

                    const predicate = (el) => {
                        // some predicate from the element
                        // return boolean
                    };

                    domTreeHelpers.showElementsWith(container, selector, predicate);
                });
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
                const btnSearchPlugin = content.find('#btn-search-plugin');
                btnSearchPlugin.on('click', (ev) => {
                    const tbSearchPlugin = content.find('#tb-search-plugin');
                    const query = {
                        pattern: tbSearchPlugin.val()
                    };

                    const currentHash = window.location.hash;
                    const hashWithQuery = queryParamsHelper.addParamsToHash(currentHash, query);

                    window.location = hashWithQuery;
                });
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