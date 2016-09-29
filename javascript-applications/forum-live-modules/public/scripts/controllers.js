const controllers = (() => {
    function login(contentId) {
        return templates.get('login')
            .then((template) => {
                const html = template();
                $(contentId).html(html);
            })
            .then(() => {
                // events
            });
    }

    return {
        login
    };
})();