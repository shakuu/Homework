const validator = (() => {
    const REGEX_LIBRARY = {
        URL_PATTERN: /((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)/,
    };

    const CONSTRAINTS = {
        STRING: {
            MIN_LENGTH: 0,
            MAX_LENGTH: Number.MAX_SAFE_INTEGER
        }
    };

    function isStringWithLength(str, min, max) {
        min = min || CONSTRAINTS.STRING.MIN_LENGTH;
        max = max || CONSTRAINTS.STRING.MAX_LENGTH;

        let isValid = true;

        const type = typeof str;
        if (type !== 'string') {
            isValid = false;
        }

        const length = str.length;
        if (!(min <= length && length <= max)) {
            isValid = false;
        }

        return isValid;
    }

    function validateUrl(url) {
        if (!url || url.length === 0) {
            return;
        }
        //copied from http://stackoverflow.com/questions/5717093/check-if-a-javascript-string-is-an-url#answer-5717133
        if (!REGEX_LIBRARY.URL_PATTERN.test(url)) {
            return {
                message: 'Invalid url'
            };
        }
    }

    return {
        validateUrl,
        string: {
            isStringWithLength
        }
    };
})();