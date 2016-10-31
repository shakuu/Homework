using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SocialNetwork.ConsoleClient.XmlDeserializers.Models
{
    /*<Image>
          <ImageUrl>http://somesite.com/SexyPicAttempt108</ImageUrl>
          <FileExtension>jpg</FileExtension>
        </Image>*/
    [Serializable]
    [XmlType(TypeName = "Image")]
    public class XmlImage
    {
        public string ImageUrl { get; set; }

        public string FileExtension { get; set; }
    }
}
