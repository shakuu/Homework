namespace Cars.Tests.JustMock.Fakes
{
    using Cars.Models;

    public class FakeCar : Car
    {
        private string make;
        private int year;

        public virtual new int Id
        {
            get
            {
                return 0;
            }
        }

        public virtual new string Make
        {
            get
            {
                return string.Empty;
            }

            set
            {
                base.Make = value;
                this.make = value;
            }

        }

        public virtual new int Year
        {
            get
            {
                return this.year;
            }

            set
            {
                base.Year = value;
                this.year = value;
            }
        }
    }
}
