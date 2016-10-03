const cryptoTools = (() => {
    function toSHA1(value) {
        const hash = CryptoJS.SHA1(value).toString(CryptoJS.enc.Latin1);
        return hash;
    }

    function toFortyCharactersSHA1(value) {
        const hash = CryptoJS.SHA1(value).toString(CryptoJS.enc.Latin1);
        const fortyCharsLong = `${hash}${hash}`;
        return fortyCharsLong;
    }

    // 64 chars
    function toSHA512(value) {
        const hash = CryptoJS.SHA512(value).toString(CryptoJS.enc.Latin1);
        return hash;
    }

    // 32 chars
    function toSHA256(value) {
        const hash = CryptoJS.SHA256(value).toString(CryptoJS.enc.Latin1);
        return hash;
    }

    return {
        toSHA1,
        toFortyCharactersSHA1,
        toSHA256,
        toSHA512
    };
})();