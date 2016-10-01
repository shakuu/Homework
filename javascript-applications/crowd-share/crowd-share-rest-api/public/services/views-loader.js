const viewsLoader = (() => {
    function load(view) {
        const viewUrl = `views/${view}.html`;
        return ajaxRequester.get(url)
            .then((view) => {
                const compiled = Handlebars.compile(view);
                return compiled;
            });
    }

    return {
        load
    };
})();   