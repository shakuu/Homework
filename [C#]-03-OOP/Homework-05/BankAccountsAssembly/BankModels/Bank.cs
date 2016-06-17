namespace BankAccountsAssembly.BankModels
{
    using AccountModels.AbstractModels;
    using System.Collections.Generic;

    public class Bank
    {
        private string _name;
        private List<Account> _accounts;

        public Bank()
        {
            this._accounts = new List<Account>();
        }

        public string Name {
            get
            {
                return this._name;
            }
            private set
            {
                this._name = value;
            }
        }

        public List<Account> Accounts {
            get
            {
                return this._accounts;
            }
            private set
            {
                this._accounts = value;
            }
        }
    }
}
