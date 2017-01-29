using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsDataBinding.WebClient
{
    public partial class Trees : System.Web.UI.Page
    {
        private string myXml =
            @"<asp:Content ContentPlaceHolderID=""MainContent"" runat=""server"">
                <asp:TreeView ID = ""MyTree"" runat=""server"">

                </asp:TreeView>
              </asp:Content>";

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}