using System;

using WebFormsMvp;

using WebFormsIntroduction.MVP.Models;
using WebFormsIntroduction.MVP.EventsArgs;

namespace WebFormsIntroduction.MVP.Views
{
    public interface IImageView : IView<ImageViewModel>
    {
        event EventHandler<ImageEventArgs> DisplayImage;
    }
}
