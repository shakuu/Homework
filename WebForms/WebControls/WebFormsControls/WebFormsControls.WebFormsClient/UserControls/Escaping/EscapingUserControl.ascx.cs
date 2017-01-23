using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsControls.EscapingTextboxes;
using WebFormsMvp.Web;

namespace WebFormsControls.WebFormsClient.UserControls.Escaping
{
    public partial class EscapingUserControl : MvpUserControl<EscapingViewModel>, IEscapingView
    {
        public event EventHandler<EscapingEventArgs> EscapeText;

        protected void OnButtonEscapeClick(object sender, EventArgs e)
        {
            this.EscapeText(this, new EscapingEventArgs(this.TextToEscape.Text));
        }
    }
}