using System;
using System.Collections;
using System.Linq;

namespace SocialNetwork.ConsoleClient.Searcher
{
    public class SocialNetworkService : ISocialNetworkService
    {
        public IEnumerable GetUsersAfterCertainDate(int year)
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetPostsByUser(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetFriendships(int page = 1, int pageSize = 25)
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetChatUsers(string username)
        {
            throw new NotImplementedException();
        }
    }
}
