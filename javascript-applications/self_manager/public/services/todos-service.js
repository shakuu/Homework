const todosService = (() => {
    const URLS = {
        GET: 'api/todos',
        POST: 'api/todos'
    };

    function getAllTodos() {
        const headers = headersHelper.addXAuthKeyHeader();        
        return ajaxRequester.get(URLS.GET, headers);
    }

    function createTodo(todo) {
        const headers = headersHelper.addXAuthKeyHeader();             
        return ajaxRequester.postJSON(URLS.POST, todo, headers);
    }

    function updateTodo(id, update) {
        const url = `${URLS.POST}/${id}`;
        const headers = headersHelper.addXAuthKeyHeader();        
        return ajaxRequester.putJSON(url, update, headers);
    }

    return {
        getAllTodos,
        createTodo,
        updateTodo
    };
})();