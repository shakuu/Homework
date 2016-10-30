using System.Collections.Generic;
using System.IO;
using System.Linq;

using Data.CodeFirst.DbContexts;
using Data.CodeFirst.Models;

using Newtonsoft.Json;

namespace Data.CodeFirst.ConsoleClient
{
    public class StaticJsonDataParser
    {
        private static DealershipsContext GetContext()
        {
            var context = new DealershipsContext();
            return context;
        }

        public static void ParseJsonData()
        {
            var files = StaticJsonDataParser.GetFilenamesList();
            foreach (var file in files)
            {
                var fileContent = File.ReadAllText(file.FullName);
                var parsedCars = JsonConvert.DeserializeObject<List<JsonCar>>(fileContent);

                var context = StaticJsonDataParser.GetContext();
                var parsedCount = parsedCars.Count;
                for (int i = 0; i < parsedCount; i++)
                {
                    var nextParsedCar = parsedCars[i];

                    if (nextParsedCar.Model.Length > 11)
                    {
                        continue;
                    }

                    if (nextParsedCar.ManufacturerName.Length > 10)
                    {
                        continue;
                    }

                    if (nextParsedCar.Dealer.Name.Length > 50)
                    {
                        continue;
                    }

                    if (nextParsedCar.Dealer.City.Length > 10)
                    {
                        continue;
                    }

                    var existingDealer = context.Dealers
                        .Where(d => d.Name == nextParsedCar.Dealer.Name && d.City.Name == nextParsedCar.Dealer.City)
                        .FirstOrDefault();

                    var existingManufacturer = context.Manufacturers
                        .Where(m => m.Name == nextParsedCar.ManufacturerName)
                        .FirstOrDefault();

                    var newCar = new Car()
                    {
                        Model = nextParsedCar.Model,
                        Price = nextParsedCar.Price,
                        TransmissionType = nextParsedCar.TransmissionType,
                        Year = nextParsedCar.Year
                    };

                    if (existingManufacturer != null)
                    {
                        newCar.Manufacturer = existingManufacturer;
                    }
                    else
                    {
                        var newManufacturer = new Manufacturer()
                        {
                            Name = nextParsedCar.ManufacturerName
                        };

                        newCar.Manufacturer = newManufacturer;
                    }

                    if (existingDealer != null)
                    {
                        newCar.Dealer = existingDealer;
                    }
                    else
                    {
                        var existingCity = context.Cities
                            .Where(c => c.Name == nextParsedCar.Dealer.City)
                            .FirstOrDefault();

                        var newDealer = new Dealer()
                        {
                            Name = nextParsedCar.Dealer.Name
                        };

                        if (existingCity != null)
                        {
                            newDealer.City = existingCity;
                        }
                        else
                        {
                            var newCity = new City()
                            {
                                Name = nextParsedCar.Dealer.City
                            };

                            newDealer.City = newCity;
                        }

                        newCar.Dealer = newDealer;
                    }

                    context.Cars.Add(newCar);

                    if (i % 50 == 0)
                    {
                        context.SaveChanges();
                        context = StaticJsonDataParser.GetContext();
                    }
                }

                context.SaveChanges();
            }
        }

        private static IEnumerable<FileInfo> GetFilenamesList()
        {
            var directory = @"../../../Data.Json.Files";
            var directoryInfo = new DirectoryInfo(directory);

            var filesList = directoryInfo.GetFiles().ToList();
            for (int i = 0; i < filesList.Count; i++)
            {
                var fileName = filesList[i];

                var isValid = StaticJsonDataParser.IsValidFileName(fileName);
                if (!isValid)
                {
                    filesList.Remove(fileName);
                    i--;
                }
            }

            return filesList;
        }

        private static bool IsValidFileName(FileInfo file)
        {
            var fileName = file.Name;
            var fileNameWords = fileName.Split('.');

            // data.number.json
            if (fileNameWords.Length != 3)
            {
                return false;
            }

            int result;
            var validNumberWord = int.TryParse(fileNameWords[1], out result);
            var validFirstWord = fileNameWords[0] == "data";
            var validLastWord = fileNameWords[2] == "json";

            var isValidName = validFirstWord && validNumberWord && validLastWord;

            return isValidName;
        }
    }
}
