var identifiable = (() => {
    const idProvider = require('../utils/id-provider')();

    var mixin = Base => class extends Base {
        constructor(args) {
            super(args);

            this.id = idProvider.next().value;
        }
    };

    return mixin;
})();

module.exports = identifiable;