using System;

namespace WebFormsControls.EscapingTextboxes
{
    public class EscapingEventArgs : EventArgs
    {
        public EscapingEventArgs(string text)
        {
            this.TextToEscape = text;
        }

        public string TextToEscape { get; set; }
    }
}
