const shareController = (() => {
    function load(containerId) {
        const content = $(containerId);

        return templatesService.loadTemplate('share')
            .then((template) => {
                const html = template();
                content.html(html);
            })
            .then(() => {
                const btnShare = content.find('#btn-share');
                btnShare.on('click', () => {
                    const tbText = content.find('#tb-cookie-text');
                    const tbCategory = content.find('tb-cookie-category');
                    const tbImage = content.find('#tb-cookie-img');
                    const cookie = {
                        text: tbText.val(),
                        category: tbCategory.val(),
                        img: tbImage.val()
                    };

                    usersController.share(cookie)
                        .then((response) => {
                            toastr.success('good');
                        })
                        .then(() => {
                            window.location = '#/';
                        })
                        .catch((error) => {
                            toastr.error('Error');
                        });
                });
            });
    }

    return {
        load
    };
})();