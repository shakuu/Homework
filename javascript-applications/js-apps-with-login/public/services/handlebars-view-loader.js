const handlebarsViewLoader = (() => {
    function load(view) {
        const viewUrl = `views/${view}.html`;
        return ajaxRequester.get(viewUrl)
            .then((view) => {
                const compiled = Handlebars.compile(view);
                return compiled;
            });
    }

    return {
        load
    };
})();   