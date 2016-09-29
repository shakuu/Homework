const templates = (() => {
    function get(template) {
        const url = `templates/${template}.html`;
        return request.get(url)
            .then((data) => {
                const compiled = Handlebars.compile(data);
                return compiled;
            });
    }

    return {
        get
    };
})();