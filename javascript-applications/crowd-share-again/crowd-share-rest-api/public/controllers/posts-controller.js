const postsController = (() => {
    function main(containerId) {
        const content = $(containerId);

        return Promise.all([
                handlebarsViewLoader.load('posts'),
                postsService.getPosts()
            ])
            .then(([view, data]) => {
                const html = view(data);
                content.html(html);
            })
            .then(() => {
                // events
                const tbPostTitle = content.find('#tb-post-title');
                const tbPostBody = content.find('#tb-post-body');

                const btnPostCreate = content.find('#btn-post-create');
                btnPostCreate.on('click', (ev) => {
                    const post = {
                        title: tbPostTitle.val(),
                        body: tbPostBody.val()
                    };

                    postsService.createPost(post)
                        .then((post) => {
                            console.log(post);
                        })
                        .catch((err) => {
                            console.log(err);
                            toastr.error(err.responseText);
                        });
                });
            })
            .catch((err) => {
                console.log(err);
                toastr.error(err.responseText);
            });
    }

    return {
        main
    };
})();