namespace AnimalHierarchy.Models
{
    using AbstractModels;
    using Types;

    public class Dog : Animal
    {
        private const string Sound = "Dog says: Woof";

        public Dog(string name, int age, SexType sex)
            : base(name, age, sex)
        {
        }

        public override void MakeASound()
        {
            System.Console.WriteLine(Sound);
        }
    }
}
