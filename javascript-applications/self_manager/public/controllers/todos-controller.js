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
            .then(() => {
                const tbTodoText = content.find('#tb-todo-text');
                const tbTodoCategory = content.find('#tb-todo-category');

                const btnTodoCreate = content.find('#btn-todo-create');
                btnTodoCreate.on('click', (ev) => {
                    const todo = {
                        text: tbTodoText.val(),
                        category: tbTodoCategory.val()
                    };

                    todosService.createTodo(todo)
                        .then((todo) => {
                            toastr.success('Item successfully created');
                        })
                        .then(() => {
                            todosController.main(containerId);
                        })
                        .catch((err) => {
                            toastr.error(err.responseText);
                        });
                });
            })
            .catch((err) => {
                console.log(err);
            });
    }

    function updateTodo(id, update) {
        return todosService.updateTodo(id, update)
            .then(() => {
                toastr.success(`Yay!`);
            })
            .then(() => {
                window.location = '#/todos';
            })
            .catch((err) => {
                toastr.error(err.responseText);
            });
    }

    return {
        main,
        updateTodo
    };
})();