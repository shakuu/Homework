using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StateManagement.WebClient
{
    public partial class HelloCookie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cookie = this.Request.Cookies["UNIQ"];
            if (cookie == null)
            {
                this.Response.Redirect(ResolveUrl("~/hellocookielogin.aspx"));
            }
            else
            {
                this.CookieContent.InnerHtml = cookie.Value;
            }
        }
    }
}