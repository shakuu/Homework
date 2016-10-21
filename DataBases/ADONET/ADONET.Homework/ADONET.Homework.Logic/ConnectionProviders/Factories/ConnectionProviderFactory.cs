using System;

using ADONET.Homework.Logic.ConnectionProviders.Contracts;
using ADONET.Homework.Logic.ConnectionProviders.Factories.Contracts;

using Ninject;

namespace ADONET.Homework.Logic.ConnectionProviders.Factories
{
    public class ConnectionProviderFactory : IConnectionProviderFactory
    {
        private readonly IKernel ninject;

        public ConnectionProviderFactory(IKernel ninject)
        {
            this.ninject = ninject;
        }

        public IConnectionProvider GetConnectionProvider(string key)
        {
            throw new NotImplementedException();
        }
    }
}
