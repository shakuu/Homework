using System;
using System.Collections.Generic;

using WebFormsDataBinding.ActualCars.Models.Contracts;
using WebFormsDataBinding.ActualCars.Models.Factories;
using WebFormsDataBinding.ActualCars.Services.Contracts;

namespace WebFormsDataBinding.ActualCars.Services
{
    public class CarsInformationService : ICarsInformationService
    {
        private readonly ICreateCarFormModelsFactory carsFactory;

        private readonly ICollection<ICarModel> existingCars;

        public CarsInformationService()
        {
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
            throw new NotImplementedException();
        }

        public IEnumerable<string> FindAvaialbleModels(string make = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> FindAvailableOptions()
        {
            throw new NotImplementedException();
        }
    }
}
