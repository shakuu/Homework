using System.Data.Entity;

using SocialNetwork.Models;

namespace SocialNetwork.Data
{
    public class SocialNetworkContext : DbContext
    {
        public SocialNetworkContext(string testDb)
        {
        }

        public SocialNetworkContext()
            : base("name=SocialNetworkDb")
        {

        }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Post> Posts { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<Friendship> Friendships { get; set; }
    }
}
