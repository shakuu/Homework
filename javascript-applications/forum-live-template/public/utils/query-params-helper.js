// const hash = window.location.hash;

const queryParamsHelper = (() => {
    function getQueryParamsFromHash(hash) {
        hash = String(hash);

        let params = {};
        if (hash.indexOf('?') < 0) {
            return params;
        }

        const inputParams = hash.split('?')[1].split('&');
        inputParams.forEach(param => {
            const split = param.split('=');
            params[split[0]] = split[1];
        });

        return params;
    }

    return {
        getQueryParamsFromHash
    };
})();