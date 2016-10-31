using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SocialNetwork.ConsoleClient.XmlParsers
{
    public static class XmlParser
    {
        public static void ParseXml(string fileLocation)
        {
            if (string.IsNullOrEmpty(fileLocation))
            {
                fileLocation = "./XmlFiles/Friendships-Test.xml";
            }

            //try
            //{

            //}
            //catch (DbEntityValidationException ex)
            //{
            //    Console.WriteLine();
            //}

            using (XmlReader xmlReader = XmlReader.Create(fileLocation))
            {
                var xmlBuilder = new StringBuilder();
                var isFriendship = false;

                while (xmlReader.Read())
                {
                    if (xmlReader.Name == "Friendship")
                    {
                        Console.WriteLine(xmlBuilder);
                        isFriendship = true;

                        var xmlExists = xmlBuilder.Length > 0;
                        if (xmlExists)
                        {
                            // Parse XML
                            xmlBuilder.Clear();
                            isFriendship = false;
                        }
                    }

                    if (isFriendship)
                    {
                        xmlBuilder.AppendLine(xmlReader.ReadOuterXml());
                    }
                }
            }
        }
    }
}
