const templatesService = (() => {
    function loadTemplate(template) {
        const templateUrl = `templates/${template}.html`;
        return requester.get(templateUrl)
            .then((data) => {
                const compiled = Handlebars.compile(data);
                return compiled;
            })
            .catch((error) => {
                toastr.error('Failed to load template!', 'Press F12 for more info.');
            });
    }

    return {
        loadTemplate
    };
})();