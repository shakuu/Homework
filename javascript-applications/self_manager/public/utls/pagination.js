const pagination = (() => {
    function paginate(container, selector, pageSize) {
        const elements = $(container).find(selector);
        if (elements.length === 0) {
            return;
        }

        const pages = splitElementsIntoPages(elements, pageSize);
        const curentPage = 0;

        displayPageNumber(pages, currentPage);

        function displayPageNumber(pages, pageNumberToDisplay) {
            for (let pageIndex = 0; pageIndex <= pages.length; pageIndex += 1) {
                const pageSize = pages[pageIndex].length;
                for (let elementIndex = 0; elementIndex <= pageSize; elementIndex += 1) {
                    if (pageNumberToDisplay === pageIndex) {
                        $(pages[pageIndex][elementIndex]).css('display', '');
                    } else {
                        $(pages[pageIndex][elementIndex]).css('display', 'none');
                    }
                }
            }
        }

        function splitElementsIntoPages(elements, pageSize) {
            const splitByPages = [];
            const numberOfPages = Math.ceil(elements.length / pageSize);
            for (let i = 0; i < numberOfPages; i += 1) {
                splitByPages[i] = [];
                for (let j = 0; j < pageSize; j += 1) {
                    const nextElementIndex = i * pageSize + j + 1;
                    if (elements[nextElementIndex]) {
                        splitByPages[i].push(elements[nextElementIndex]);
                    } else {
                        break;
                    }
                }
            }

            return splitByPages;
        }
    }

    function unpaginate() {

    }

    return {
        paginate,
        unpaginate
    };
})();