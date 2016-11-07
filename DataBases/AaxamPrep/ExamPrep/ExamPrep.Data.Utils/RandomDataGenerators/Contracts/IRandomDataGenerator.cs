using System;

namespace ExamPrep.Data.Utils.RandomDataGenerators.Contracts
{
    public interface IRandomDataGenerator
    {
        string GenerateString(int length);

        int GenerateIntValue(int maxValue, int minValue = 0);

        DateTime GenerateDate(int maxYear, int minYear = 1990);
    }
}
