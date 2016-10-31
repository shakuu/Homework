using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SocialNetwork.ConsoleClient.XmlDeserializers.Models
{
    /*<FirstUser>
      <Username>Pesho</Username>
      <FirstName>Pesho</FirstName>
      <LastName>Peshov</LastName>
      <RegisteredOn>2010-02-20T09:12:45</RegisteredOn>
      <Images>
        <Image>
          <ImageUrl>http://somesite.com/SexyPicAttempt108</ImageUrl>
          <FileExtension>jpg</FileExtension>
        </Image>
        <Image>
          <ImageUrl>http://somesite.com/WithMyCar</ImageUrl>
          <FileExtension>jpg</FileExtension>
        </Image>
        <Image>
          <ImageUrl>http://somesite.com/SelfieInTheBathroom</ImageUrl>
          <FileExtension>jpg</FileExtension>
        </Image>
      </Images>
    </FirstUser>*/
    [Serializable]
    public class XmlUser
    {
        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RegisteredOn { get; set; }

        [XmlArrayItem(ElementName = "Image")]
        public List<XmlImage> Images { get; set; }
    }
}
