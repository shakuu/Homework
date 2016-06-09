
namespace AnimalHierarchy.Models.CatsModels
{
    using System;
    using Types;

    public class TomCat : Cat
    {
        private const string Sound = "TomCat says: Whatchu doin'";

        public TomCat(string name, int age, SexType sex) 
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
                if (value == SexType.Female)
                {
                    throw new ArgumentException("TomCats can only be boys");
                }

                base.Sex = SexType.Male;
            }
        }

        public override void MakeASound()
        {
            Console.WriteLine(Sound);
        }
    }
}
