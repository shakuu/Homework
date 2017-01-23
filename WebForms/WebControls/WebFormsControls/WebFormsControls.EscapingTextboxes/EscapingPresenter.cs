using WebFormsMvp;

namespace WebFormsControls.EscapingTextboxes
{
    public class EscapingPresenter : Presenter<IEscapingView>
    {
        private readonly IEscapingView view;

        public EscapingPresenter(IEscapingView view)
            : base(view)
        {
            this.view = view;

            this.view.EscapeText += this.OnEscapeText;
        }

        private void OnEscapeText(object sender, EscapingEventArgs args)
        {
            this.view.Model.EscapedText = args.TextToEscape;
        }
    }
}
