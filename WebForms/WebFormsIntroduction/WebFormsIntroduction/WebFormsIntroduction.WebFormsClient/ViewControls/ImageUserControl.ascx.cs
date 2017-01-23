using System;

using WebFormsIntroduction.MVP.EventsArgs;
using WebFormsIntroduction.MVP.Models;
using WebFormsIntroduction.MVP.Presenters;
using WebFormsIntroduction.MVP.Views;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace WebFormsIntroduction.WebFormsClient.ViewControls
{
    [PresenterBinding(typeof(ImagePresenter))]
    public partial class ImageUserControl : MvpUserControl<ImageViewModel>, IImageView
    {
        public event EventHandler<ImageEventArgs> DisplayImage;

        protected void DisplayImage_Click(object sender, EventArgs e)
        {
            this.DisplayImage(this, new ImageEventArgs(this.ImageText.Text));
        }
    }
}