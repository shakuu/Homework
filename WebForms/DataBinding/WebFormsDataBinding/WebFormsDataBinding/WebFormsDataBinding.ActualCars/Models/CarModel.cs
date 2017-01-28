using System.Collections.Generic;

using WebFormsDataBinding.ActualCars.Models.Contracts;

namespace WebFormsDataBinding.ActualCars.Models
{
    public class CarModel : ICarModel
    {
        public CarModel(string make, string model, IEnumerable<string> options)
        {
            this.Make = make;
            this.Model = model;
            this.Options = options;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public IEnumerable<string> Options { get; set; }
    }
}
