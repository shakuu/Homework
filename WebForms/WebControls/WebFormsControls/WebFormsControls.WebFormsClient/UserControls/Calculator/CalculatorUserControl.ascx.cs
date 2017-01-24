using System;
using System.Web.UI.WebControls;
using WebFormsControls.Calculator;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace WebFormsControls.WebFormsClient.UserControls.Calculator
{
    [PresenterBinding(typeof(CalculatorPresenter))]
    public partial class CalculatorUserControl : MvpUserControl<CalculatorViewModel>, ICalculatorView
    {
        public event EventHandler<CalculatorEventArgs> UserInput;

        protected void OnButtonClick(object sender, EventArgs e)
        {
            var senderButton = sender as Button;
            if (senderButton == null)
            {
                throw new ArgumentException();
            }
            else
            {
                var prev = Session["prev"] as string;
                var current = Session["current"] as string;
                var operation = Session["operation"] as string;

                this.UserInput(this, new CalculatorEventArgs(senderButton.Text, prev, current, operation));

                Session.RemoveAll();
                Session.Add("prev", this.Model.PreviousValue);
                Session.Add("current", this.Model.CurrentValue);
                Session.Add("operation", this.Model.EnqueuedOperation);
            }
        }
    }
}