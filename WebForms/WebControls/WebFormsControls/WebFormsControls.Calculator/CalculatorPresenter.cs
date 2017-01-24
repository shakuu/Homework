using WebFormsControls.Calculator.CalculatorServices.Contracts;

using WebFormsMvp;

namespace WebFormsControls.Calculator
{
    public class CalculatorPresenter : Presenter<ICalculatorView>
    {
        private readonly ICalculatorView view;
        private readonly ICalculatorService calculatorService;

        public CalculatorPresenter(ICalculatorView view, ICalculatorService calculatorService)
            : base(view)
        {
            this.view = view;
            this.view.UserInput += this.OnUserInput;

            this.calculatorService = calculatorService;
        }

        private void OnUserInput(object sender, CalculatorEventArgs args)
        {
            this.view.Model.DisplayValue = "1";
        }
    }
}
