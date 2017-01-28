using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WebFormsDataBinding.Cars.Models;
using WebFormsDataBinding.Cars.Services.Contracts;

namespace WebFormsDataBinding.Cars.Services
{
    public class CarsService : ICarsService
    {
        private static Random random;

        private IEnumerable<string> allMakes = new[]
        {
            "BMW",
            "AUDI",
            "FORD",
            "VW",
            "KIA"
        };

        private IList<string> allOptions = new[]
        {
            "Night Vision",
            "Massaging Seats",
            "Autonomous Driving",
            "Fully Armored"
        };

        private readonly IDictionary<string, ICollection<string>> modelsByMake;

        private readonly IDictionary<string, ICollection<Car>> carsByMake;

        static CarsService()
        {
            CarsService.random = new Random();
        }

        public CarsService()
        {
            this.modelsByMake = this.CreateModelNames();
            this.carsByMake = this.CreateCars();
        }

        public IEnumerable<string> AllAvailableMakes()
        {
            return this.allMakes;
        }

        public IEnumerable<string> AllAvailableModels(string make = null)
        {
            if (make == null)
            {
                make = this.allMakes.First();
            }

            var modelsToReturn = this.modelsByMake[make];
            return modelsToReturn;
        }

        public IEnumerable<string> AllAvailableOptions()
        {
            return this.allOptions;
        }

        public IEnumerable<Car> FindCars(string make, IEnumerable<string> options)
        {
            var modelsCollection = this.carsByMake[make];

            var filteredByOption = modelsCollection.Where(car =>
            {
                var isMatch = true;
                foreach (var option in options)
                {
                    var hasOption = car.Options.Contains(option);
                    if (!hasOption)
                    {
                        isMatch = false;
                        break;
                    }
                }

                return isMatch;
            });

            return filteredByOption;
        }

        private IDictionary<string, ICollection<string>> CreateModelNames()
        {
            var modelNames = new Dictionary<string, ICollection<string>>();
            foreach (var make in this.allMakes)
            {
                modelNames.Add(make, new List<string>());

                var modelsCount = CarsService.random.Next(1, 17);
                for (int i = 0; i < modelsCount; i++)
                {
                    var currentModelName = new StringBuilder();

                    var modelNameLength = CarsService.random.Next(3, 9);
                    for (int charIndex = 0; charIndex < modelNameLength; charIndex++)
                    {
                        var nextChar = (char)(CarsService.random.Next(0, 26) + 'a');
                        currentModelName.Append(nextChar);
                    }

                    var modelName = currentModelName.ToString();
                    modelNames[make].Add(modelName);
                }
            }

            return modelNames;
        }

        private IDictionary<string, ICollection<Car>> CreateCars()
        {
            var cars = new Dictionary<string, ICollection<Car>>();
            foreach (var kvp in this.modelsByMake)
            {
                var make = kvp.Key;
                cars.Add(make, new List<Car>());

                foreach (var model in kvp.Value)
                {
                    var options = this.CreateOptionsList();
                    var nextCar = new Car(make, model, options);

                    cars[make].Add(nextCar);
                }
            }

            return cars;
        }

        private ICollection<string> CreateOptionsList()
        {
            var options = new List<string>();

            var optionsCount = CarsService.random.Next(1, 3);
            for (int i = 0; i < optionsCount; i++)
            {
                var nextOptionIndex = CarsService.random.Next(0, this.allOptions.Count);
                options.Add(this.allOptions[nextOptionIndex]);
            }

            return options;
        }
    }
}
