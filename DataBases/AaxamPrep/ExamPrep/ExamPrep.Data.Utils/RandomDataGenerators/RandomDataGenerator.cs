using System;
using System.Text;

using ExamPrep.Data.Utils.RandomDataGenerators.Contracts;

namespace ExamPrep.Data.Utils.RandomDataGenerators
{
    public class RandomDataGenerator : IRandomDataGenerator
    {
        private static readonly Random Random;
        private static readonly int AllowedSymblosCount = AllowedSymbols.Length;

        private const string AllowedSymbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        static RandomDataGenerator()
        {
            Random = new Random();
        }

        public DateTime GenerateDate(int maxYear, int minYear = 1990)
        {
            var year = RandomDataGenerator.Random.Next(minYear, maxYear);
            var month = RandomDataGenerator.Random.Next(1, 12);
            var day = RandomDataGenerator.Random.Next(1, 28);

            var date = new DateTime(year, month, day);
            return date;
        }

        public int GenerateIntValue(int maxValue, int minValue = 0)
        {
            var value = RandomDataGenerator.Random.Next(minValue, maxValue);
            return value;
        }

        public string GenerateString(int length)
        {
            var generatedString = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                var nextSymbolIndex = RandomDataGenerator.Random.Next(0, RandomDataGenerator.AllowedSymblosCount);
                var nextSymbol = RandomDataGenerator.AllowedSymbols[nextSymbolIndex];
                generatedString.Append(nextSymbol);
            }

            return generatedString.ToString();
        }
    }
}
