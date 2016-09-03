const SavingsAccountMixin = Base => class extends Base {
    constructor(rate, ...args) {
        super(...args);
        console.log(rate);
    }
};

module.exports = SavingsAccountMixin;