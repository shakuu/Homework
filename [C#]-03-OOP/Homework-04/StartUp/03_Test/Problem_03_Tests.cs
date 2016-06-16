namespace StartUp._03_Test
{
    using AnimalHierarchy.AbstractModels;
    using AnimalHierarchy.Models;
    using AnimalHierarchy.Models.CatsModels;
    using AnimalHierarchy.Types;
    using Randomizers;
    using System;
    using System.Linq;

    /// <summary>
    /// Create arrays of different kinds of animals 
    /// and calculate the average age of each kind of animal 
    /// using a static method (you may use LINQ).
    /// </summary>
    public static class Problem_03_Tests
    {
        #region Static Fields and Ctor
        private static Random random;

        static Problem_03_Tests()
        {
            random = new Random();
        }
        #endregion

        public static void Tasks()
        {
            Console.WriteLine("Problem 3. Animal hierarchy Tasks: " + Environment.NewLine);

            var animals = CreateArray(random.Next(50, 200));

            var avgAge = AverageAge(typeof(Cat), animals);
            Console.WriteLine($"Average Age of {nameof(Cat)} is {avgAge}.");

            avgAge = AverageAge(typeof(Kitten), animals);
            Console.WriteLine($"Average Age of {nameof(Kitten)} is {avgAge}.");

            avgAge = AverageAge(typeof(TomCat), animals);
            Console.WriteLine($"Average Age of {nameof(TomCat)} is {avgAge}.");

            avgAge = AverageAge(typeof(Dog), animals);
            Console.WriteLine($"Average Age of {nameof(Dog)} is {avgAge}.");

            avgAge = AverageAge(typeof(Frog), animals);
            Console.WriteLine($"Average Age of {nameof(Frog)} is {avgAge}.");
        }

        private static double AverageAge(Type type, Animal[] animals)
        {
            var result = 0d;

            var output =
                (from animal in animals
                 where animal != null
                 where animal.GetType() == type
                 select animal.Age).ToList();

            try
            {
                // possible div by 0
                result = output.Sum() / output.Count;
            }
            catch (Exception)
            {
                return 0;
            }

            return result;
        }

        private static Animal[] CreateArray(int size)
        {
            var output = new Animal[size];

            for (int i = 0; i < size; i++)
            {
                var name = Generators.GenerateName(random);
                var age = random.Next(0, 21);
                var sex = random.Next(0, 2);
                var type = random.Next(0, 6);

                Animal animal;
                try
                {
                    switch (type)
                    {
                        case 0:
                            animal = new Cat(name, age, (SexType)sex);
                            break;
                        case 1:
                            animal = new Kitten(name, age, (SexType)sex);
                            break;
                        case 2:
                            animal = new TomCat(name, age, (SexType)sex);
                            break;
                        case 3:
                            animal = new Dog(name, age, (SexType)sex);
                            break;
                        default:
                            animal = new Frog(name, age, (SexType)sex);
                            break;
                    }
                }
                catch (ArgumentException)
                {
                    continue;
                }


                output[i] = animal;
            }

            return output;
        }
    }
}
