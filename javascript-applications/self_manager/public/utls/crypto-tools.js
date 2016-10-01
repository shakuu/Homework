const cryptoTools = (() => {
    function encrypt(value) {
        const hash = CryptoJS.SHA1(value).toString(CryptoJS.enc.Base64);
        return hash;
    }

    return {
        encrypt
    };
})();