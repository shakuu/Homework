const validator = (() => {
    const REGEX_LIBRARY = {

    };

    const CONSTRAINTS = {
        STRING: {
            MIN_LENGTH: 0,
            MAX_LENGTH: Number.MAX_SAFE_INTEGER
        }
    };

    function stringLength(str, min, max) {
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

    return {
        string: {
            stringLength
        }
    };
})();