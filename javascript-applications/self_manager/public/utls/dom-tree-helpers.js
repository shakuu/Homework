const domTreeHelpers = (() => {
    function showElementsWith(container, selector, predicate) {
        const elements = $(container).find(selector);
        _.forEach(elements, el => {
            if (predicate(el)) {
                $(el).css('display', '');
            } else {
                $(el).css('display', 'none');
            }
        });
    }

    function hideElementsWith(container, selector, predicate) {
        const elements = $(container).find(selector);
        _.forEach(elements, el => {
            if (predicate(el)) {
                $(el).css('display', 'none');
            } else {
                $(el).css('display', '');
            }
        });
    }

    return {
        showElementsWith,
        hideElementsWith
    };
})();