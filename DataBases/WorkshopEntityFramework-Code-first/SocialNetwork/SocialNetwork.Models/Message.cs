using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Newtonsoft.Json;

namespace SocialNetwork.Models
{
    /*It is associated with Friendship
        It has Author
        Content which is required
        SentOn field type date which is an index
        SeenOn field type date which is nullable*/
    public class Message
    {
        public int Id { get; set; }

        [JsonIgnore]
        public User Author { get; set; }

        [Required]
        public string Content { get; set; }

        [Index]
        public DateTime SentOn { get; set; }

        public DateTime? SeenOn { get; set; }

        public int FriendshipId { get; set; }

        public virtual Friendship Friendship { get; set; }
    }
}
