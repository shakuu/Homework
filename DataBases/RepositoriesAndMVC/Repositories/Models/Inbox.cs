using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SqlModels
{
    public class Inbox
    {
        private ICollection<Message> messages;

        public Inbox()
        {
            this.messages = new HashSet<Message>();
        }

        [Key, ForeignKey("User")]
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public ICollection<Message> Messages
        {
            get
            {
                return this.messages;
            }
            set
            {
                this.messages = value;
            }
        }
    }
}
