const SavingsMixin = require('../mixins/savings-mixin');
const BankAccount = require('./account');

class SavingsBankAccount extends SavingsMixin(BankAccount) {
    constructor(rate, owner, number) {
        super(rate, owner, number);
    }
}

module.exports = SavingsBankAccount;