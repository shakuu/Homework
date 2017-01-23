using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;

namespace WebFormsIntroduction.WebFormsClient.HttpHandlers
{
    public class ImgHandler : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        // Displaying images
        // http://stackoverflow.com/questions/21675067/convert-text-to-image
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/png";

            var text = context.Request.Params["text"];
            if (text == null) text = string.Empty;
            var image = ConvertTextToImage(text, "Arial", 22, Color.Black, Color.White, 300, 300);

            image.Save(context.Response.OutputStream, ImageFormat.Png);
        }

        public Bitmap ConvertTextToImage(string txt, string fontname, int fontsize, Color bgcolor, Color fcolor, int width, int Height)
        {
            Bitmap bmp = new Bitmap(width, Height);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {

                Font font = new Font(fontname, fontsize);
                graphics.FillRectangle(new SolidBrush(bgcolor), 0, 0, bmp.Width, bmp.Height);
                graphics.DrawString(txt, font, new SolidBrush(fcolor), 0, 0);
                graphics.Flush();
                font.Dispose();
                graphics.Dispose();


            }
            return bmp;
        }

        #endregion
    }
}
