const homeController = (() => {
    function main(containerId) {
        const content = $(containerId);
        content.html('');
    }

    return {
        main
    };
})();