const pagination = (() => {
    function paginate(container, selector, inputPageSize) {
        const content = $(container);
        if (content.length === 0) {
            return;
        }

        const elements = content.find(selector);
        if (elements.length === 0) {
            return;
        }

        let pageSize = Number(inputPageSize);
        if (isNaN(pageSize)) {
            return;
        }

        if (!(0 < pageSize && pageSize <= 50)) {
            return;
        }

        let currentPage = 0;
        let pages = splitElementsIntoPages(elements, pageSize);
        displayPageNumber(pages, currentPage);

        handlebarsViewLoader.load('paginate-addon')
            .then((view) => {
                const html = view();
                content.prepend(html);
            })
            .then(() => {
                const btnPrevious = content.find('#btn-previous');
                btnPrevious.on('click', (ev) => {
                    currentPage -= 1;
                    if (currentPage < 0) {
                        currentPage = 0;
                    }

                    displayPageNumber(pages, currentPage);
                });

                const btnNext = content.find('#btn-next');
                btnNext.on('click', (ev) => {
                    currentPage += 1;
                    if (pages.length <= currentPage) {
                        currentPage = pages.length - 1;
                    }

                    displayPageNumber(pages, currentPage);
                });

                const tbPageSize = content.find('#tb-page-size');
                tbPageSize.val(pageSize);
                tbPageSize.on('change', (ev) => {
                    currentPage = 0;
                    pageSize = Number(tbPageSize.val());
                    pages = splitElementsIntoPages(elements, pageSize);
                    displayPageNumber(pages, currentPage);
                });
            });

        function displayPageNumber(pages, pageNumberToDisplay) {
            for (let pageIndex = 0; pageIndex < pages.length; pageIndex += 1) {
                const pageSize = pages[pageIndex].length;
                for (let elementIndex = 0; elementIndex < pageSize; elementIndex += 1) {
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
                    const nextElementIndex = i * pageSize + j;
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