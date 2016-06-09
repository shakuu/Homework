
namespace StudentsAndWorkers.AbstractModels
{
    public abstract class Human
    {
        private string first;
        private string last;

        public Human(string first, string last)
        {
            this.FirstName = first;
            this.LastName = last;
        }

        #region Properties
        public string FirstName
        {
            get
            {
                return this.first;
            }
            set
            {
                this.first = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.last;
            }
                        set
            {
                this.last = value;
            }
        }


        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
        #endregion
    }
}
