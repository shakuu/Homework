
namespace AcademyEcosystem
{
    using System;

    internal static class MealValidation
    {
        internal static void CheckIfMealIsNull<T>(T meal)
            where T : IOrganism
        {
            if (meal == null)
            {
                throw new ArgumentNullException("Meal cannot be null");
            }
        }

        internal static void CheckIfMealIsOfSuitableSize(int carnivoreSize, int potentialPreySize, int carnivoreSizeModifier = 1)
        {
            if (carnivoreSize * carnivoreSizeModifier > potentialPreySize)
            {
                throw new ArgumentException("Prey Animal is too large to be eaten");
            }
        }
    }
}
