using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsMvp;
using WebFormsMvp.Web;
using WebFormsTest.Models;
using WebFormsTest.Presenters;
using WebFormsTest.Views;

namespace WebFormsTest.Controls
{
    [PresenterBinding(typeof(SamplePresenter))]
    public partial class SampleControl : MvpUserControl<SampleModel>, ISampleView
    {
        public event EventHandler<GetAllEventArgs> Finding;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}