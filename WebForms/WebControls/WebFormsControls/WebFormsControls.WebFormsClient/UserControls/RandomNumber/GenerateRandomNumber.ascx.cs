using System;

using WebFormsControls.RandomNumber;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace WebFormsControls.WebFormsClient.UserControls.RandomNumber
{
    [PresenterBinding(typeof(IRandomPresenter))]
    public partial class GenerateRandomNumber : MvpUserControl<RandomViewModel>, IRandomView
    {
        public event EventHandler<RandomEventArgs> Generate;

        protected void OnButtonGenerateClick(object sender, EventArgs e)
        {
            var minimumValue = this.MinimumValue.Text;
            var maximumValue = this.MaximumValue.Text;
            var eventArgs = new RandomEventArgs(minimumValue, maximumValue);

            this.Generate(this, eventArgs);
        }
    }
}