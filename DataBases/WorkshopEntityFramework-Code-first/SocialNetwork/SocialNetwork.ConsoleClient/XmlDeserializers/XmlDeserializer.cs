using SocialNetwork.ConsoleClient.XmlDeserializers.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SocialNetwork.ConsoleClient.XmlDeserializers
{
    public class XmlDeserializer
    {
        public static void DeserializeTo()
        {
            var xml = new XmlSerializer(typeof(List<XmlPost>), new XmlRootAttribute("Posts"));

            using (var fs = new FileStream("./XmlFiles/Posts-Test.xml", FileMode.Open))
            {
                var result = (List<XmlPost>)xml.Deserialize(fs);
            }
        }

        public static void DeserializeToFriendShip()
        {
            var xml = new XmlSerializer(typeof(List<XmlFriendship>), new XmlRootAttribute("Friendships"));

            using (var fs = new FileStream("./XmlFiles/Friendships-Test.xml", FileMode.Open))
            {
                var result = (List<XmlFriendship>)xml.Deserialize(fs);
            }
        }
    }
}
