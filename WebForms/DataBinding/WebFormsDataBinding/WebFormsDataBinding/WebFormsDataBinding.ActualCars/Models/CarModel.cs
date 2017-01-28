using System.Collections.Generic;

using WebFormsDataBinding.ActualCars.Models.Contracts;

namespace WebFormsDataBinding.ActualCars.Models
{
    public class CarModel : ICarModel
    {
        public CarModel(string make, string model, ICollection<string> options)
        {
            this.Make = make;
            this.Model = model;
            this.Options = options;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public ICollection<string> Options { get; set; }

        public override int GetHashCode()
        {
            var hash = 199;

            unchecked
            {
                hash = hash * 127 + this.Make.GetHashCode();
                hash = hash * 127 + this.Model.GetHashCode();

                foreach (var option in this.Options)
                {
                    hash = hash * 127 + option.GetHashCode();
                }
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            var otherCar = obj as CarModel;
            if (otherCar == null)
            {
                return false;
            }

            var makeIsEqual = this.Make == otherCar.Make;
            var modelIsEqual = this.Model == otherCar.Model;

            var optionsAreEqual = this.Options.Count == otherCar.Options.Count;
            if (optionsAreEqual)
            {
                var thisOptionsEnumerator = this.Options.GetEnumerator();
                var otherOptionsEnumerator = otherCar.Options.GetEnumerator();

                while (thisOptionsEnumerator.MoveNext() && otherOptionsEnumerator.MoveNext())
                {
                    var thisValue = thisOptionsEnumerator.Current;
                    var otherValue = otherOptionsEnumerator.Current;

                    var optionIsEqual = thisValue == otherValue;
                    if (!optionIsEqual)
                    {
                        optionsAreEqual = false;
                        break;
                    }
                }
            }

            return makeIsEqual && modelIsEqual && optionsAreEqual;
        }
    }
}
