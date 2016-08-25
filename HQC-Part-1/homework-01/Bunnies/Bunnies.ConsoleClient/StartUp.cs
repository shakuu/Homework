namespace Bunnies.ConsoleClient
{
    using System.Collections.Generic;
    using System.IO;

    using Bunnies.Contracts;
    using Bunnies.Enums;
    using Bunnies.Models;
    using Bunnies.Utils;

    public class Startup
    {
        public static void Main()
        {
            var bunnies = CreateListOfBunnies();

            var consoleWriter = new ConsoleWriter();
            foreach (var bunny in bunnies)
            {
                bunny.Introduce(consoleWriter);
            }

            var bunniesFilePath = @"..\..\bunnies.txt";
            var file = File.Create(bunniesFilePath);
            file.Close();

            using (var streamWriter = new StreamWriter(bunniesFilePath))
            {
                foreach (var bunny in bunnies)
                {
                    streamWriter.WriteLine(bunny.ToString());
                }

                streamWriter.Close();
            }
        }

        private static IEnumerable<IBunny> CreateListOfBunnies()
        {
            var bunnies = new List<IBunny>
            {
                new Bunny
                {
                    Age = 1,
                    Name = "Leonid",
                    FurType = FurType.NotFluffy
                },
                new Bunny
                {
                    Age = 2,
                    Name = "Rasputin",
                    FurType = FurType.ALittleFluffy
                },
                new Bunny
                {
                    Age = 3,
                    Name = "Tiberii",
                    FurType = FurType.ALittleFluffy
                },
                new Bunny
                {
                    Age = 1,
                    Name = "Neron",
                    FurType = FurType.ALittleFluffy
                },
                new Bunny
                {
                    Age = 3,
                    Name = "Klavdii",
                    FurType = FurType.Fluffy
                },
                new Bunny
                {
                    Age = 3,
                    Name = "Vespasian",
                    FurType = FurType.Fluffy
                },
                new Bunny
                {
                    Age = 4,
                    Name = "Domician",
                    FurType = FurType.FluffyToTheLimit
                },
                new Bunny
                {
                    Age = 2,
                    Name = "Tit",
                    FurType = FurType.FluffyToTheLimit
                }
            };

            return bunnies;
        }
    }
}
