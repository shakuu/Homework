const categoriesService = (() => {
    const URL = 'api/categories';

    function allCategories() {
        return requester.get(URL);
    }

    return {
        allCategories
    };
})();