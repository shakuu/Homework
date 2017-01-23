using System;

using WebFormsMvp;

namespace WebFormsControls.EscapingTextboxes
{
    public interface IEscapingView : IView<EscapingViewModel>
    {
        event EventHandler<EscapingEventArgs> EscapeText;
    }
}
