namespace AnimalHierarchy.Models
{
    using AbstractModels;
    using Types;

    public class Frog : Animal
    {
        private const string Sound = "Frog says: Don't eat me!";

        public Frog(string name, int age, SexType sex) 
            : base(name, age, sex)
        {
        }

        public override void MakeASound()
        {
            System.Console.WriteLine(Sound);
        }
    }
}
