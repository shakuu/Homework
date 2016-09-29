const Navigo = require('../../bower_components/navigo/lib/navigo.min');

const Router = (() => {
    class Router {
        constructor() {
            this.__initRouter__();
        }

        __initRouter__() {
            this._router = new Navigo(null, true);
            
        }
    }

    return Router;
})();

module.exports = Router;