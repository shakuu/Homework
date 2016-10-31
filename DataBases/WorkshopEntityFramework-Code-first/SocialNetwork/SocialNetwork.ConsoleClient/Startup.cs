namespace SocialNetwork.ConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Searcher;
    using System.Xml;
    using XmlParsers;

    public class Startup
    {

        public static void Main()
        {
            //          var xml =
            //              @"<Friendship Approved=""true"">
            //  <FriendsSince>2012-05-30T09:36:07</FriendsSince>
            //  <FirstUser>
            //    <Username>Pesho</Username>
            //    <FirstName>Pesho</FirstName>
            //    <LastName>Peshov</LastName>
            //    <RegisteredOn>2010-02-20T09:12:45</RegisteredOn>
            //    <Images>
            //      <Image>
            //        <ImageUrl>http://somesite.com/SexyPicAttempt108</ImageUrl>
            //        <FileExtension>jpg</FileExtension>
            //      </Image>
            //      <Image>
            //        <ImageUrl>http://somesite.com/WithMyCar</ImageUrl>
            //        <FileExtension>jpg</FileExtension>
            //      </Image>
            //      <Image>
            //        <ImageUrl>http://somesite.com/SelfieInTheBathroom</ImageUrl>
            //        <FileExtension>jpg</FileExtension>
            //      </Image>
            //    </Images>
            //  </FirstUser>
            //  <SecondUser>
            //    <Username>Gosho</Username>
            //    <FirstName>Gosho</FirstName>
            //    <LastName>Goshov</LastName>
            //    <RegisteredOn>2009-07-20T19:07:12</RegisteredOn>
            //    <Images>
            //      <Image>
            //        <ImageUrl>http://somesite.com/SeaFeetPic</ImageUrl>
            //        <FileExtension>png</FileExtension>
            //      </Image>
            //      <Image>
            //        <ImageUrl>http://somesite.com/MyFoodShkembe</ImageUrl>
            //        <FileExtension>png</FileExtension>
            //      </Image>
            //    </Images>
            //  </SecondUser>
            //  <Messages>
            //    <Message>
            //      <Author>Pesho</Author>
            //      <Content>Sha odim li na hija?</Content>
            //      <SentOn>2015-10-21T11:03:27</SentOn>
            //      <SeenOn>2015-10-21T11:03:50</SeenOn>
            //    </Message>
            //    <Message>
            //      <Author>Gosho</Author>
            //      <Content>Epa noo qsno!</Content>
            //      <SentOn>2015-10-21T11:03:53</SentOn>
            //      <SeenOn>2015-10-21T11:04:01</SeenOn>
            //    </Message>
            //    <Message>
            //      <Author>Pesho</Author>
            //      <Content>Idealka vzimam domasharkata</Content>
            //      <SentOn>2015-10-21T11:04:27</SentOn>
            //      <SeenOn>2015-10-21T11:03:50</SeenOn>
            //    </Message>
            //  </Messages>
            //</Friendship>";

            //          var doc = new XmlDocument();
            //          doc.LoadXml(xml);

            //          var root = doc.DocumentElement;
            //          var isApproved = root.Attributes["Approved"].Value;
            //          Console.WriteLine(isApproved);
            
            //try
            //{

            //}
            //catch (DbEntityValidationException ex)
            //{
            //    Console.WriteLine();
            //}
            
            XmlParser.ParseFriendShipsXml(null);
        }
    }
}
