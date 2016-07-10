namespace AcademyEcosystem.Animals
{
    // TODO : DELETE

    internal static class Eatery
    {
        internal static int EatAnimal(this Animal carnivore, Animal target, int maxAllowedSizeModifier = 1)
        {
            var quantityOfMeatEaten = 0;

            if (target.Size <= carnivore.Size * maxAllowedSizeModifier)
            {
                quantityOfMeatEaten = target.GetMeatFromKillQuantity();
            }

            return quantityOfMeatEaten;
        }
        
    }
}
