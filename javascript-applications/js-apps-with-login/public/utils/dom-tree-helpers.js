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