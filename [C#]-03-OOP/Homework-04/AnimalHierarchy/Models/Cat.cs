namespace AnimalHierarchy.Models
{
    using AbstractModels;
    using System;
    using Types;

    public class Cat : Animal
    {
        private const string Sound = "Cat says: Miaw";

        public Cat(string name, int age, SexType sex) :
            base(name, age, sex)
        {
        }

        public override void MakeASound()
        {
            Console.WriteLine(Sound);
        }
    }
}
