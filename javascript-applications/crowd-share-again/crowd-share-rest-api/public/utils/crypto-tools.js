const cryptoTools = (() => {
    function toSHA1(value) {
        const hash = CryptoJS.SHA1(value).toString();
        return hash;
    }

    // 64 chars
    function toSHA512(value) {
        const hash = CryptoJS.SHA512(value).toString();
        return hash;
    }

    // 32 chars
    function toSHA256(value) {
        const hash = CryptoJS.SHA256(value).toString();
        return hash;
    }

    return {
        toSHA1,
        toSHA256,
        toSHA512
    };
})();