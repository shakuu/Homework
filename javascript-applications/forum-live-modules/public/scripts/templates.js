const templates = (() => {
    function get(template) {
        return request.get('login')
            .then((data) => {
                const compiled = Handlebars.compile(data);
                return compiled;
            });
    }

    return {
        get
    };
})();