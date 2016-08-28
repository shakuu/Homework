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
        private const string BunniesFilePath = @"..\..\bunnies.txt";

        public static void Main(string[] args)
        {
            var bunnies = CreateListOfBunnies();

            var consoleWriter = new ConsoleWriter();
            foreach (var bunny in bunnies)
            {
                bunny.Introduce(consoleWriter);
            }

            var fileName = GetFileName(args);
            using (var streamWriter = new StreamWriter(fileName))
            {
                foreach (var bunny in bunnies)
                {
                    streamWriter.WriteLine(bunny.ToString());
                }

                streamWriter.Close();
            }
        }

        private static string GetFileName(string[] commandLineArguments)
        {
            string fileName;
            FileStream fileStream;

            try
            {
                fileName = commandLineArguments[0];
                fileStream = File.Create(fileName);
            }
            catch (IOException)
            {
                fileName = Startup.BunniesFilePath;
                fileStream = File.Create(fileName);
            }

            fileStream.Close();

            return fileName;
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
