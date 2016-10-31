using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SocialNetwork.Models
{
    /* It has two users
        It has an Approved field type boolean which is index
        FriendsSince type date
        It has Messages*/
    public class Friendship
    {
        private ICollection<Message> messages;

        public Friendship()
        {
            this.messages = new HashSet<Message>();
        }

        public int Id { get; set; }

        [JsonIgnore]
        public User UserA { get; set; }

        [JsonIgnore]
        public User UserB { get; set; }

        public bool Approved { get; set; }

        public DateTime FriendsSince { get; set; }

        public virtual ICollection<Message> Messages
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
