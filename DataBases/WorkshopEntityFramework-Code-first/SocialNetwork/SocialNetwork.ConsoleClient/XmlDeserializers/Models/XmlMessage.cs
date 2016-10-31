using System;
using System.Xml.Serialization;

namespace SocialNetwork.ConsoleClient.XmlDeserializers.Models
{
    /*<Message>
        <Author>Pesho</Author>
        <Content>Idealka vzimam domasharkata</Content>
        <SentOn>2015-10-21T11:04:27</SentOn>
        <SeenOn>2015-10-21T11:03:50</SeenOn>
      </Message>*/
    [Serializable]
    [XmlType(TypeName = "Message")]
    public class XmlMessage
    {
        public string Author { get; set; }

        public string Content { get; set; }

        public DateTime SentOn { get; set; }

        public DateTime? SeenOn { get; set; }
    }
}
