using WebFormsIntroduction.MVP.EventsArgs;
using WebFormsIntroduction.MVP.Views;

using WebFormsMvp;

namespace WebFormsIntroduction.MVP.Presenters
{
    public class ImagePresenter : Presenter<IImageView>
    {
        private readonly IImageView view;

        public ImagePresenter(IImageView view)
            : base(view)
        {
            this.view = view;

            this.view.DisplayImage += this.OnDisplayImage;
        }

        private void OnDisplayImage(object sender, ImageEventArgs args)
        {
            var url = "Default.img?text=" + args.ImageText;
            this.view.Model.ImageUrl = url;
        }
    }
}
