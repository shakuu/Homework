using System;

using WebFormsControls.EscapingTextboxes;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace WebFormsControls.WebFormsClient.UserControls.Escaping
{
    [PresenterBinding(typeof(EscapingPresenter))]
    public partial class EscapingUserControl : MvpUserControl<EscapingViewModel>, IEscapingView
    {
        public event EventHandler<EscapingEventArgs> EscapeText;

        protected void OnButtonEscapeClick(object sender, EventArgs e)
        {
            var text = Server.HtmlEncode(this.TextToEscape.Text);
            this.EscapeText(this, new EscapingEventArgs(text));
            
            this.LabelEnteredText.Text = this.Model.EscapedText;
        }
    }
}