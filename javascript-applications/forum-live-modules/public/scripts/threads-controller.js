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

    function getThreadMessages(contentId, id) {
        const container = $(contentId);

        Promise.all([
            templates.get('thread-messages'),
            threadsDataService.getById(id)
        ])
            .then(([template, data]) => {
                const html = template(data.result);
                container.html(html);
            });
    }

    function addMessageToThreadWith(contentId, id) {
        const container = $(contentId);
        const messageContent = container.find('#tb-message-content');
        const message = {
            test: messageContent.val()
        };

        return threadsDataService.addMessage(id, message);
    }

    return {
        allThreads,
        addThread,
        getThreadMessages,
        addMessageToThreadWith
    };
})();