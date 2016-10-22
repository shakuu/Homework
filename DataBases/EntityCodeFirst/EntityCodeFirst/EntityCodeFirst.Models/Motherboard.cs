using System.Collections.Generic;

namespace EntityCodeFirst.Models
{
    public class Motherboard
    {
        private ICollection<PersonalComputer> computers;

        public Motherboard()
        {
            this.computers = new HashSet<PersonalComputer>();
        }

        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public decimal? Price { get; set; }

        public virtual ICollection<PersonalComputer> Computers
        {
            get
            {
                return this.computers;
            }

            set
            {
                this.computers = value;
            }
        }
    }
}
