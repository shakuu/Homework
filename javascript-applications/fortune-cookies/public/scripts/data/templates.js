const templatesService = (() => {
    function loadTemplate(template) {
        const templateUrl = `templates/${template}.html`;
        return requester.get(templateUrl)
            .then((data) => {
                const compiled = Handlebars.compile(data);
                return compiled;
            });
    }

    return {
        loadTemplate
    };
})();