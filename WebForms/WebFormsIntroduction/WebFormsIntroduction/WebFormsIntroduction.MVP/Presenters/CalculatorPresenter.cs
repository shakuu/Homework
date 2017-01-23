using System;

using WebFormsIntroduction.MVP.Views;

using WebFormsMvp;

namespace WebFormsIntroduction.MVP.Presenters
{
    public class CalculatorPresenter : Presenter<ICalculaterView>
    {
        private ICalculaterView view;

        public CalculatorPresenter(ICalculaterView view)
            : base(view)
        {
            this.view = view;

            this.view.Sum += this.OnSum;
        }

        private void OnSum(object sender, EventArgs args)
        {
            this.view.Model.Result = this.view.Model.ValueA + this.view.Model.ValueB;
        }
    }
}
