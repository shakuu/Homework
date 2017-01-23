using System;

using WebFormsMvp;

using WebFormsIntroduction.MVP.EventsArgs;
using WebFormsIntroduction.MVP.Views;

namespace WebFormsIntroduction.MVP.Presenters
{
    public class CalculatorPresenter : Presenter<ICalculatorView>
    {
        private ICalculatorView view;

        public CalculatorPresenter(ICalculatorView view)
            : base(view)
        {
            this.view = view;

            this.view.Sum += this.OnSum;
        }

        private void OnSum(object sender, CalculatorEventArgs args)
        {
            try
            {
                var valueA = decimal.Parse(args.ValueA);
                var valueB = decimal.Parse(args.ValueB);
                var sum = valueA + valueB;

                this.view.Model.Result = sum.ToString();
            }
            catch (Exception)
            {
                this.view.Model.Result = "Naughty!";
            }
        }
    }
}
