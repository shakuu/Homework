using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DataSourceControls.WebClient
{
    public partial class Countries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ContinentsListBox.SelectedIndex = 0;
                this.CountriesGridView.SelectedIndex = 0;
            }
        }
    }
}