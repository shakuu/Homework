const TemplateLoaderService = (() => {
    class TemplateLoaderService {
        constructor(requestsProvider) {
            this._requests = requestsProvider;
        }

        get(template) {
            const url = `/templates/${template}.html`;
            return this._requests.get(url)
                .then((data) => {
                    const compiled = Handlebars.compile(data);
                    return compiled;
                });
        }
    }

    return TemplateLoaderService;
})();

module.exports = TemplateLoaderService;