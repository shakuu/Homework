
namespace AnimalHierarchy.Models.CatsModels
{
    using System;
    using Types;

    public class Kitten : Cat
    {
        private const string Sound = "Kitten says: Miaw Miaw";

        public Kitten(string name, int age, SexType sex) 
            : base(name, age, sex)
        {
        }

        public override SexType Sex
        {
            get
            {
                return base.Sex;
            }

            protected set
            {
                if (value == SexType.Male)
                {
                    throw new ArgumentException("Kittens can only be girls");
                }
                base.Sex = SexType.Female;
            }
        }

        public override void MakeASound()
        {
            Console.WriteLine(Sound);
        }
    }
}
