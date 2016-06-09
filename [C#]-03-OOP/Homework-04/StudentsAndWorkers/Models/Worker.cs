namespace StudentsAndWorkers.Models
{
    using AbstractModels;

    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal workHoursPerDay;

        public Worker(string first, 
            string last, 
            decimal weekSalary, 
            decimal hoursDay)
            : base(first, last)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = hoursDay;
        }

        #region Properties
        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                this.weekSalary = value;
            }
        }

        public decimal WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                this.workHoursPerDay = value;
            }
        }
        #endregion

        public decimal MoneyPerHour()
        {
            return this.WeekSalary / this.WorkHoursPerDay;
        }

        public override string ToString()
        {
            return base.FullName + $", Wage: {this.MoneyPerHour().ToString("F2")}/ hour";
        }
    }
}
