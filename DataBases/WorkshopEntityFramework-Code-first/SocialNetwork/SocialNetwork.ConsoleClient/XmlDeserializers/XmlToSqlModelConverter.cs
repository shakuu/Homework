using System;
using System.Collections.Generic;

using SocialNetwork.ConsoleClient.XmlDeserializers.Models;
using SocialNetwork.Data;
using SocialNetwork.Models;

namespace SocialNetwork.ConsoleClient.XmlDeserializers
{
    public class XmlToSqlModelConverter
    {
        private readonly Func<SocialNetworkContext> contextCreator;

        public XmlToSqlModelConverter(Func<SocialNetworkContext> contextCreator)
        {
            this.contextCreator = contextCreator;
        }

        public void ConvertXmlFriendshipToSqlFriendship(IEnumerable<XmlFriendship> xmlFriendships)
        {
            if (xmlFriendships == null)
            {
                throw new ArgumentNullException(nameof(xmlFriendships));
            }

            var context = this.contextCreator();

            var friendshipCount = 0;
            foreach (var friendship in xmlFriendships)
            {
                friendshipCount++;

                var newFriendship = new Friendship();


            }
        }
    }
}
