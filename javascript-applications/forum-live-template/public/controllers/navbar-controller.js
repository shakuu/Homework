const navbarController = (() => {
    const btnGlobalLogin = $('#btn-global-login');
    const btnGlobalLogout = $('#btn-global-logout');

    function displayControls() {
        const userIsLoggedIn = credentialManager.isLogged();
        if (userIsLoggedIn) {
            btnGlobalLogin.hide();
            btnGlobalLogout.show();
        } else {
            btnGlobalLogin.show();
            btnGlobalLogout.hide();
        }
    }

    return {
        displayControls
    };
})();