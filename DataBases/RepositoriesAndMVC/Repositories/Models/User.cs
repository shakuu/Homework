using System.Collections.Generic;

namespace Models
{
    public class User
    {
        private ICollection<Message> sent;
        private ICollection<Message> received;

        public User()
        {
            this.sent = new HashSet<Message>();
            this.received = new HashSet<Message>();
        }

        public User(string username)
        {
            this.Username = username;
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public int InboxId { get; set; }

        public virtual Inbox Inbox { get; set; }

        public int OutboxId { get; set; }

        public virtual Outbox Outbox { get; set; }
    }
}
