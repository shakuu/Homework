const TemplateLoader = (() => {
    class TemplateLoader {
        constructor(requestsProvider) {
            this._requests = requestsProvider;
        }

        load(template) {
            const url = `/templates/${template}.html`;
            return this._requests.get(url)
                .then((data) => {
                    const compiled = Handlebars.compile(data);
                    return compiled;
                });
        }
    }

    return TemplateLoader;
})();

module.exports = TemplateLoader;