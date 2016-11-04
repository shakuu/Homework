using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Message
    {
        public int Id { get; set; }

        public string Content { get; set; }
        
        public int FromUserId { get; set; }

        public virtual User FromUser { get; set; }

        public int ToUserId { get; set; }

        public virtual User ToUser { get; set; }
    }
}
