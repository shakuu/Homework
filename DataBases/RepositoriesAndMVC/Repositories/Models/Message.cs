using System.ComponentModel.DataAnnotations.Schema;

namespace SqlModels
{
    public class Message
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int FromUserId { get; set; }

        public int InboxId { get; set; }

        public virtual Inbox Inbox { get; set; }

        public int OutboxId { get; set; }

        public virtual Outbox Outbox { get; set; }
    }
}
