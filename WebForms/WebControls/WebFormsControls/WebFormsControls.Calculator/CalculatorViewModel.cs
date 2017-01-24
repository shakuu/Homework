namespace WebFormsControls.Calculator
{
    public class CalculatorViewModel
    {
        public CalculatorViewModel()
        {
            this.DisplayValue = "0";
        }

        public string DisplayValue { get; set; }

        public string PreviousValue { get; set; }

        public string CurrentValue { get; set; }

        public string EnqueuedOperation { get; set; }
    }
}
