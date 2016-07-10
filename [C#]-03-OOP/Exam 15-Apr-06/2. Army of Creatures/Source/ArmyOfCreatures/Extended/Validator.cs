namespace ArmyOfCreatures.Extended
{
    using System;

    using ArmyOfCreatures.Logic.Battles;

    internal static class Validator
    {
        internal static void CheckCreaturesForNull(
            ICreaturesInBattle first, string firstName,
            ICreaturesInBattle second, string secondName)
        {
            if (first == null)
            {
                throw new ArgumentNullException(firstName);
            }

            if (second == null)
            {
                throw new ArgumentNullException(secondName);
            }
        }

        internal static void CheckValidRange(int value, int minimum = 0, int maximum = int.MaxValue)
        {
            if (value < minimum || maximum < value)
            {
                throw new ArgumentOutOfRangeException("rounds", "The number of rounds should be greater than 0");
            }
        }
    }
}
