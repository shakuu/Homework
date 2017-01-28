using System.Collections.Generic;

namespace WebFormsDataBinding.ActualCars.Models.Contracts
{
    public interface ICarModel
    {
        string Make { get; set; }

        string Model { get; set; }

        ICollection<string> Options { get; set; }
    }
}
