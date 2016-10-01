const todosController = (() => {
    function main(containerId) {
        return Promise.all([
                handlebarsViewLoader.load('todos'),
                todosService.getAllTodos()
            ])
            .then(([view, todos]) => {
                console.log(todos);
            })
            .catch((err) => {
                console.log(err);
            });
    }

    return {
        main
    };
})();