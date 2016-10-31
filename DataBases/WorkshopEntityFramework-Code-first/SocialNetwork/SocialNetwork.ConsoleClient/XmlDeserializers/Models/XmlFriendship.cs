using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SocialNetwork.ConsoleClient.XmlDeserializers.Models
{
    [Serializable]
    [XmlType(TypeName = "Friendship")]
    public class XmlFriendship
    {
        [XmlAttribute]
        public bool Approved { get; set; }

        public DateTime? FriendsSince { get; set; }

        public XmlUser FirstUser { get; set; }

        public XmlUser SecondUser { get; set; }

        [XmlArrayItem(ElementName = "Message")]
        public List<XmlMessage> Messages { get; set; }
    }
}
