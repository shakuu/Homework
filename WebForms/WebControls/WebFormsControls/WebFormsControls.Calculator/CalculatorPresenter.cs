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
            this.calculatorService.RestoreState(args.CurrentValue, args.PreviousValue, args.EnqueuedOperation);
            this.view.Model.DisplayValue = this.calculatorService.HandleInput(args.Input);
            this.view.Model.CurrentValue = this.calculatorService.CurrentValue;
            this.view.Model.PreviousValue = this.calculatorService.PreviousValue;
            this.view.Model.EnqueuedOperation = this.calculatorService.EnqueuedOperation;
        }
    }
}
