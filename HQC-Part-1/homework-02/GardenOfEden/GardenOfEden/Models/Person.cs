using GardenOfEden.Enums;

namespace GardenOfEden.Models
{
    public class Person
    {
        private Person()
        {
        }

        public GenderType Gender { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public static Person Create(int age)
        {
            var newPerson = new Person();

            newPerson.Age = age;
            if (age % 2 == 0)
            {
                newPerson.Name = "Dude";
                newPerson.Gender = GenderType.Male;
            }
            else
            {
                newPerson.Name = "Dudette";
                newPerson.Gender = GenderType.Female;
            }

            return newPerson;
        }
    }
}