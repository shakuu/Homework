using System.Collections;
using System.Linq;

using SocialNetwork.Data;

namespace SocialNetwork.ConsoleClient.Searcher
{
    public class SocialNetworkService : ISocialNetworkService
    {
        private SocialNetworkContext CreateContext()
        {
            var context = new SocialNetworkContext();
            return context;
        }

        public IEnumerable GetUsersAfterCertainDate(int year)
        {
            var context = this.CreateContext();
            var users = context.Users
                .Where(u => u.RegisteredOn.Year > year)
                .ToList();

            return users;
        }

        public IEnumerable GetPostsByUser(string username)
        {
            var context = this.CreateContext();
            var posts = context.Users
                .Where(u => u.Username == username)
                .SelectMany(u => u.Posts)
                .Select(p => new {
                    PostedOn = p.PostedOn,
                    Content = p.Content,
                    Users = p.TaggedUsers
                })
                .ToList();

            return posts;
        }

        public IEnumerable GetFriendships(int page = 1, int pageSize = 25)
        {
            var context = this.CreateContext();
            var friendships = context.Friendships
                .Where(f => f.Approved == true)
                .OrderBy(f => f.FriendsSince)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(f => new
                {
                    FirstUserUsername = f.UserA.Username,
                    FirstUserImage = f.UserA.Images.FirstOrDefault(),
                    SecondUserUsername = f.UserB.Username,
                    SecondUserImage = f.UserB.Images.FirstOrDefault()
                })
                .ToList();

            return friendships;
        }

        public IEnumerable GetChatUsers(string username)
        {
            var context = this.CreateContext();
            var users = context.Friendships
                .Where(f => f.UserA.Username == username || f.UserB.Username == username)
                .Where(f => f.Messages.Count >= 1)
                .Select(f=> f.UserA.Username == username ? f.UserB.Username : f.UserA.Username)
                .Distinct()
                .ToList();

            return users;
        }
    }
}
