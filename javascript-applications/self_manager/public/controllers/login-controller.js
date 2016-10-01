const loginController = (() => {
    function main(containerId) {
        const content = $(containerId);

        return handlebarsViewLoader.load('login')
            .then((view) => {
                const html = view();
                content.html(html);
            })
            .catch((error) => {
                toastr.error(error.responseText);
            });
    }

    return {
        main
    };
})();