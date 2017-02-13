using System;
using System.Web;

namespace StateManagement.WebClient
{
    public partial class HelloCookieLogin : System.Web.UI.Page
    {
        public void OnSubmit(object sender, EventArgs e)
        {
            var cookie = new HttpCookie("UNIQ", this.Username.Value + " " + this.Password.Value);
            cookie.Expires = DateTime.Now.AddMinutes(1);

            this.Response.Cookies.Add(cookie);
            this.Response.Redirect(ResolveUrl("~/hellocookie.aspx"));
        }
    }
}