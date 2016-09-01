using System;
using System.Reflection;

using _03_Porcupines.Forests.Contracts;
using _03_Porcupines.Forests.Enums;

namespace _03_Porcupines.Forests
{
    public class ForestCellFactory : IForestCellFactory
    {
        private ConstructorInfo forestCellConstructor;

        public ForestCellFactory(Type type)
        {
            var getIForestCell = type.GetInterface("IForestCell");
            if (getIForestCell == null)
            {
                throw new ArgumentException("Invalid type.");
            }

            this.forestCellConstructor = this.GetConstructor(type);
        }

        public IForestCell CreateForestCell(ForestCellContentType contentType, int points = 0)
        {
            var constructorParameters = new object[] { contentType, points };
            var newForestCell = (IForestCell)this.forestCellConstructor.Invoke(constructorParameters);

            return newForestCell;
        }

        private ConstructorInfo GetConstructor(Type type)
        {
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var constructorParametersTypes = new[] { typeof(ForestCellContentType), typeof(int) };
            var constructor = type.GetConstructor(bindingFlags, null, constructorParametersTypes, null);
            if (constructor == null)
            {
                throw new ArgumentException("Could not find constructor.");
            }

            return constructor;
        }
    }
}
