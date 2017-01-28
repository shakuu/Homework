using System.Collections.Generic;
using System.Linq;

using WebFormsDataBinding.ActualCars.Models.Contracts;
using WebFormsDataBinding.ActualCars.Models.Factories;
using WebFormsDataBinding.ActualCars.Services.Contracts;

namespace WebFormsDataBinding.ActualCars.Services
{
    public class CarsInformationService : ICarsInformationService
    {
        private readonly ICreateCarFormModelsFactory carsFactory;

        private readonly ICollection<ICarModel> existingCars;

        private IEnumerable<string> availableMakes;

        private IDictionary<string, ICollection<string>> modelsByMake;

        private IEnumerable<string> availableOptions;

        public CarsInformationService()
        {
            this.availableMakes = this.CreateAvailableMakes();
            this.modelsByMake = this.CreateModelsByMake();
            this.availableOptions = this.CreateAvailableOptions();

            this.existingCars = new HashSet<ICarModel>();
        }

        public CarsInformationService(ICreateCarFormModelsFactory carsFactory)
        {
            this.carsFactory = carsFactory;
        }

        public ICarModel FindOrCreateCar(string make, string model, ICollection<string> options)
        {
            var car = this.carsFactory.CreateCarModel(make, model, options);
            this.existingCars.Add(car);

            return car;
        }

        public IEnumerable<string> FindAvailableMakes()
        {
            return this.availableMakes;
        }

        public IEnumerable<string> FindAvaialbleModels(string make = null)
        {
            if (make == null)
            {
                make = this.availableMakes.First();
            }

            return this.modelsByMake[make];
        }

        public IEnumerable<string> FindAvailableOptions()
        {
            return this.availableOptions;
        }

        private IEnumerable<string> CreateAvailableMakes()
        {
            var availableMakes = new[]
            {
                "Audi",
                "BMW",
                "Ford",
                "VW"
            };

            return availableMakes;
        }

        private IDictionary<string, ICollection<string>> CreateModelsByMake()
        {
            var modelsByMake = new Dictionary<string, ICollection<string>>();

            modelsByMake.Add("Audi", new HashSet<string>() { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8" });
            modelsByMake.Add("BMW", new HashSet<string>() { "M1", "M3", "M4", "M5", "M6" });
            modelsByMake.Add("Ford", new HashSet<string>() { "Fiesta", "Focus", "Mondeo", "Edge" });
            modelsByMake.Add("VW", new HashSet<string>() { "Polo", "Golf", "Rabbit", "Tiguan", "Touareg" });

            return modelsByMake;
        }

        private IEnumerable<string> CreateAvailableOptions()
        {
            var availableOptions = new[]
            {
                "Autonomous Driving",
                "Massaging Seats",
                "Armour"
            };

            return availableOptions;
        }
    }
}
