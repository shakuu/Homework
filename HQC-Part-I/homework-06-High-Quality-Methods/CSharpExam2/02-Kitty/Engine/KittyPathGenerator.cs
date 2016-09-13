using System;
using System.Collections.Generic;
using System.Reflection;

using _02_Kitty.Engine.Contracts;
using _02_Kitty.Engine.Enums;

namespace _02_Kitty.Engine
{
    public class KittyPathGenerator : IPathGenerator
    {
        private const char Food = '*';
        private const char CoderSoul = '@';
        private const char Deadlock = 'x';

        private ConstructorInfo pathCellConstructor;

        public KittyPathGenerator(Type pathCellType)
        {
            if (pathCellType == null)
            {
                throw new ArgumentNullException("pathCellType");
            }

            var implementsIPathCell = pathCellType.GetInterface("IPathCell");
            if (implementsIPathCell == null)
            {
                throw new ArgumentException("pathCellType");
            }

            this.pathCellConstructor = this.GetPathCellConstructor(pathCellType);
        }

        public IList<IPathCell> CreatePath(string path)
        {
            var isOdd = false;
            var pathCells = new List<IPathCell>();
            foreach (var symbol in path)
            {
                var newCellContent = this.GetCellContentType(symbol);
                var constructorParameters = new object[] { newCellContent, isOdd };
                var newPathCell = (IPathCell)this.pathCellConstructor.Invoke(constructorParameters);
                pathCells.Add(newPathCell);

                isOdd = !isOdd;
            }

            return pathCells;
        }

        private CellConentType GetCellContentType(char symbol)
        {
            CellConentType result;
            switch (symbol)
            {
                case KittyPathGenerator.Food:
                    result = CellConentType.Food;
                    break;
                case KittyPathGenerator.CoderSoul:
                    result = CellConentType.CoderSoul;
                    break;
                case KittyPathGenerator.Deadlock:
                    result = CellConentType.Deadlock;
                    break;
                default:
                    throw new ArgumentNullException("content");
            }

            return result;
        }

        private ConstructorInfo GetPathCellConstructor(Type pathCellType)
        {
            var bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            var constructorParameterTypes = new[] { typeof(CellConentType), typeof(bool) };
            var constructor = pathCellType.GetConstructor(bindingFlags, null, constructorParameterTypes, null);

            return constructor;
        }
    }
}
