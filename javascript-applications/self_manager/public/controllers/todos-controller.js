const todosController = (() => {
    function main(containerId) {
        const content = $(containerId);

        return Promise.all([
                handlebarsViewLoader.load('todos'),
                todosService.getAllTodos()
            ])
            .then(([view, todos]) => {
                const html = view(todos.result);
                content.html(html);
            })
            .catch((err) => {
                console.log(err);
            });
    }

    return {
        main
    };
})();