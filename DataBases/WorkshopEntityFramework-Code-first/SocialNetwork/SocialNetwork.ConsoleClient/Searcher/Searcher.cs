using System.Collections;
using System.IO;

using Newtonsoft.Json;

namespace SocialNetwork.ConsoleClient.Searcher
{
    public class DataSearcher
    {
        public static void Search(ISocialNetworkService searcher)
        {
            var users = searcher.GetUsersAfterCertainDate(2013);
            var postsByUsers = searcher.GetPostsByUser("ZtlKYHVN7h8SwMmaJs");
            var friendships = searcher.GetFriendships(2, 10);
            var chatUsers = searcher.GetChatUsers("ZtlKYHVN7h8SwMmaJs");

            DataSearcher.SaveToJson(users, nameof(users));
            DataSearcher.SaveToJson(postsByUsers, nameof(postsByUsers));
            DataSearcher.SaveToJson(friendships, nameof(friendships));
            DataSearcher.SaveToJson(chatUsers, nameof(chatUsers));
        }

        private static void SaveToJson(IEnumerable data, string fileName)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            var fileNameWithExtension = $"./Json/{fileName}.json";

            File.WriteAllText(fileNameWithExtension, json);
        }
    }
}
