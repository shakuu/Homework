using System;

namespace WebFormsIntroduction.MVP.EventsArgs
{
    public class ImageEventArgs : EventArgs
    {
        public ImageEventArgs(string imageText)
        {
            this.ImageText = imageText;
        }

        public string ImageText { get; set; }
    }
}
