using System;

using WebFormsMvp;
using WebFormsMvp.Web;

using WebFormsIntroduction.MVP.EventsArgs;
using WebFormsIntroduction.MVP.Models;
using WebFormsIntroduction.MVP.Presenters;
using WebFormsIntroduction.MVP.Views;

namespace WebFormsIntroduction.WebFormsClient.ViewControls
{
    [PresenterBinding(typeof(CalculatorPresenter))]
    public partial class CalculatorUserControl : MvpUserControl<CalculatorViewModel>, ICalculaterView
    {
        public event EventHandler<CalculatorEventArgs> Sum;
        
        protected void Sum_Click(object sender, EventArgs e)
        {
            var eventArgs = new CalculatorEventArgs(this.ValueA.Text, this.ValueB.Text);
            this.Sum(this, eventArgs);
        }
    }
}