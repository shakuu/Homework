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
                    const tbCategory = content.find('#tb-cookie-category');
                    const tbImage = content.find('#tb-cookie-img');
                    const cookie = {
                        text: tbText.val(),
                        category: tbCategory.val(),
                        img: tbImage.val()
                    };

                    const isValidCookie = isValid(cookie);
                    if (!isValidCookie) {
                        toastr.error('Invalid lenght or characters');
                        return new Promise((resolve, reject) => {
                            resolve();
                        });
                    }

                    return usersController.share(cookie)
                        .then((response) => {
                            toastr.success('good');
                        })
                        .then(() => {
                            window.location = '#/';
                        })
                        .catch((error) => {
                            toastr.error('Error');
                        });

                    function isValid(cookie) {
                        const hasValidText = validateString(cookie.text);
                        const hasValidCategory = validateString(cookie.category);

                        return hasValidText && hasValidCategory;

                        function validateString(value) {
                            const isString = typeof value === 'string';
                            const isValidLength = 6 <= value.length && value.length <= 30;
                            const containsOnlyCharacters = /^[A-Za-z]+$/.test(value);

                            return isString && isValidLength && containsOnlyCharacters;
                        }
                    }
                });
            });
    }

    return {
        load
    };
})();