const cryptoTools = (() => {
    function encrypt(value) {
        const hash = CryptoJS.SHA256(value);
        return hash;
    }

    return {
        encrypt
    };
})();