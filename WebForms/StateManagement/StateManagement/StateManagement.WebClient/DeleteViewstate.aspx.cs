using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement.WebClient
{
    public partial class DeleteViewstate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ClientScript.RegisterClientScriptInclude("deleteViewstate", ResolveUrl("~/Scripts/delete-viewstate.js"));
        }
    }
}