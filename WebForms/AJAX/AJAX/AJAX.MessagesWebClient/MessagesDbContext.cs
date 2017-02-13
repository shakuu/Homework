using System.Data.Entity;

namespace AJAX.MessagesWebClient
{
    public class MessagesDbContext : DbContext
    {
        public MessagesDbContext()
            : base("name=MessagesDb")
        {

        }

        public virtual DbSet<Message> Messages { get; set; }
    }
}