using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace AJAX.MessagesWebClient
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new MessagesDbContext();
            var messages = db.Messages.OrderByDescending(msg => msg.PostedOn).Take(100).ToList();

            this.MessagesRepeater.DataSource = messages;
            this.MessagesRepeater.DataBind();
        }

        public void OnNewMessage(object sender, EventArgs e)
        {
            var newMessage = new Message();
            newMessage.Content = this.AddMessageTextBox.Text;

            var db = new MessagesDbContext();
            db.Messages.Add(newMessage);
            db.SaveChanges();

            var messages = db.Messages.OrderByDescending(msg => msg.PostedOn).Take(100).ToList();

            this.MessagesRepeater.DataSource = messages;
            this.MessagesRepeater.DataBind();
        }
    }
}