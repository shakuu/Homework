using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using ADONET.Homework.Logic.CommandProviders.Contracts;
using ADONET.Homework.Logic.ConnectionProviders.Contracts;
using ADONET.Homework.Logic.Factories.Contracts;

namespace ADONET.Homework.Logic.Factories
{
    public class DbFactory : IDbFactory
    {
        private readonly IDictionary<string, Type> commandProviders;
        private readonly IDictionary<string, Type> connectionProviders;

        public DbFactory()
        {
            this.commandProviders = this.FindTypesImplementing(typeof(ICommandProvider));
            this.connectionProviders = this.FindTypesImplementing(typeof(IConnectionProvider));
        }

        public ICommandProvider CreateCommandProvider(string key)
        {
            ICommandProvider instance;

            Type typeToCreate;
            var typeIsFound = this.commandProviders.TryGetValue(key, out typeToCreate);
            if (typeIsFound)
            {
                instance = (ICommandProvider)Activator.CreateInstance(typeToCreate);
            }
            else
            {
                throw new ArgumentException("type not found");
            }

            return instance;
        }

        public IConnectionProvider CreateConnectionProvider(string key)
        {
            IConnectionProvider instance;

            Type typeToCreate;
            var typeIsFound = this.commandProviders.TryGetValue(key, out typeToCreate);
            if (typeIsFound)
            {
                instance = (IConnectionProvider)Activator.CreateInstance(typeToCreate);
            }
            else
            {
                throw new ArgumentException("type not found");
            }

            return instance;
        }

        private IDictionary<string, Type> FindTypesImplementing(Type implementedInterface)
        {
            var assembly = Assembly.GetAssembly(this.GetType());
            var commandProviders = assembly
                .GetTypes()
                .Where(type => type.IsClass && type.IsInstanceOfType(implementedInterface));

            var dictionary = new Dictionary<string, Type>();
            foreach (var type in commandProviders)
            {
                dictionary.Add(type.Name, type);
            }

            return dictionary;
        }
    }
}
