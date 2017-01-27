using System.Collections.Generic;

namespace WebFormsDataBinding.Cars.Models
{
    public class Car
    {
        private ICollection<string> options;

        public Car(string make, string model, ICollection<string> options)
        {
            this.Make = make;
            this.Model = model;

            if (options != null)
            {
                this.options = options;
            }
            else
            {
                this.options = new HashSet<string>();
            }
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public virtual ICollection<string> Options
        {
            get
            {
                return this.options;
            }

            set
            {
                this.options = value;
            }
        }
    }
}
