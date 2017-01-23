using WebFormsMvp;

namespace WebFormsControls.Calculator
{
    public class CalculatorPresenter : Presenter<ICalculatorView>
    {
        private readonly ICalculatorView view;

        public CalculatorPresenter(ICalculatorView view)
            : base(view)
        {
            this.view = view;
            this.view.UserInput += this.OnUserInput;
        }

        private void OnUserInput(object sender, CalculatorEventArgs args)
        {
            this.view.Model.DisplayValue = "1";
        }
    }
}
