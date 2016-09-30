const app = (() => {
    function start() {
        router.resolve();
    }

    return {
        start
    };
})();

$(() => {
    app.start();
});