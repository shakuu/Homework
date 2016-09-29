const threadsController = (() => {
    function allThreads(contentId) {
        const container = $(contentId);

        Promise.all([
            templates.get('all-threads'),
            threadsDataService.getAll()
        ])
            .then(([template, data]) => {
                const html = template(data.result);
                container.html(html);
                console.log(data);
                return [template, data.result];
            });
    }

    function addThread(contentId) {
        const container = $(contentId);

        const title = container.find('#tb-thread-title');
        const thread = {
            title: title.val()
        };

        threadsDataService.addNew(thread)
            .then((data) => {
                window.location = '#/threads';
            });
    }

    return {
        allThreads,
        addThread
    };
})();