using SocialNetwork.Data;

namespace SocialNetwork.ConsoleClient.XmlDeserializers
{
    public class ContextProvider
    {
        public static SocialNetworkContext CreateSocialNetworkContext()
        {
            var context = new SocialNetworkContext();
            return context;
        }
    }
}
