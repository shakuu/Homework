using System;

namespace AJAX.MessagesWebClient
{
    public class Message
    {
        public Message()
        {
            this.Id = Guid.NewGuid();
            this.PostedOn = DateTime.UtcNow;
        }

        public Guid Id { get; set; }

        public string Content { get; set; }

        public DateTime PostedOn { get; set; }
    }
}