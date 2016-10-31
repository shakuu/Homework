using System;
using System.Xml.Serialization;

namespace SocialNetwork.ConsoleClient.XmlDeserializers.Models
{
    /*<Post>
    <Content>Qm mandja</Content>
    <PostedOn>2010-02-20T09:12:45</PostedOn>
    <Users>Pesho,Gosho</Users>
  </Post>*/
    [Serializable]
    [XmlType(TypeName = "Post")]
    public class XmlPost
    {
        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

        public string Users { get; set; }
    }
}
