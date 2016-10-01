const eventsController = (() => {
    function main(containerId) {
        const content = $(containerId);

        return Promise.all([
                handlebarsViewLoader.load('events'),
                eventsService.getAllEvents()
            ])
            .then(([view, events]) => {
                // console.log(events);
                const html = view(events.result);
                content.html(html);
            })
            .catch((err) => {
                toastr.error(err.responseText);
            });
    }

    return {
        main
    };
})();