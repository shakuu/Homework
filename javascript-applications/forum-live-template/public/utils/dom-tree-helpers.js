// Example predicate:
//
// const hash = window.location.hash;
// const queryParams = queryParamsHelper.getQueryParamsFromHash(hash);
//
// const queryParamsKeys = Object.keys(queryParams);
// if (queryParamsKeys.length === 0) {
//     return;
// }
//
// 
// const predicate = (element) => {
//     const field = $(element).find(`.${queryParamsKeys[0]}`);
//     const isMatch = field.html() === queryParams[queryParamsKeys[0]];
//     return isMatch;
// };
//
// domTreeHelpers.showElementsWith('#content', '.todo', predicate);

const domTreeHelpers = (() => {
    function showElementsWith(container, selector, predicate) {
        const elements = $(container).find(selector);
        if (elements.length === 0) {
            return;
        }

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
        if (elements.length === 0) {
            return;
        }

        _.forEach(elements, el => {
            if (predicate(el)) {
                $(el).css('display', 'none');
            } else {
                $(el).css('display', '');
            }
        });
    }

    // Sample sorting predicate.
    //
    // const predicate = (el) => {
    //     const username = $(el).find('#username').html();
    //     return username;
    // };
    function orderElementsBy(container, selector, predicate) {
        const elements = $(container).find(selector);
        if (elements.length === 0) {
            return;
        }

        const sortedElements = _.sortBy(elements, (el) => predicate(el));
        elements.remove();                
        $(container).append(sortedElements);
    }

    return {
        showElementsWith,
        hideElementsWith,
        orderElementsBy
    };
})();