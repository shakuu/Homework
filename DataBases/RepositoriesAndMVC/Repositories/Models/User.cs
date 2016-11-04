using System.Collections.Generic;

namespace Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
