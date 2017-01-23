using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsIntroduction.MVP.Models;
using WebFormsIntroduction.MVP.Presenters;
using WebFormsIntroduction.MVP.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace WebFormsIntroduction.WebFormsClient.ViewControls
{
    [PresenterBinding(typeof(CalculatorPresenter))]
    public partial class CalculatorUserControl : MvpUserControl<CalculatorViewModel>, ICalculaterView
    {
        public event EventHandler Sum;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Sum_Click(object sender, EventArgs e)
        {
            try
            {
                this.Model.ValueA = decimal.Parse(this.ValueA.Text);
                this.Model.ValueB = decimal.Parse(this.ValueB.Text);

                this.Sum(this, null);
            }
            catch (Exception)
            {
                this.Model.Result = "Naughty!";
            }
        }
    }
}