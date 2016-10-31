using System;
using System.Linq;
using System.Xml;

using SocialNetwork.Models;
using SocialNetwork.Data;

namespace SocialNetwork.ConsoleClient.XmlReaderExtensionMethods
{
    public static class XmlExtensions
    {
        public static Post CreatePost(this XmlReader reader, SocialNetworkContext context)
        {
            var newPost = new Post();

            var isContent = false;
            var isPostedOn = false;
            var isUsers = false;

            while (reader.Read())
            {
                var readerName = reader.Name;

                if (readerName == "Post")
                {
                    break;
                }
                else if (readerName == "Content")
                {
                    isContent = !isContent;
                }
                else if (readerName == "PostedOn")
                {
                    isPostedOn = !isPostedOn;
                }
                else if (readerName == "Users")
                {
                    isUsers = !isUsers;
                }
                else if (isContent)
                {
                    newPost.Content = reader.Value;
                }
                else if (isPostedOn)
                {
                    newPost.PostedOn = DateTime.Parse(reader.Value);
                }
                else if (isUsers)
                {
                    var elementValue = reader.Value;
                    var userList = elementValue.Split(',').Select(u => u.Trim());

                    var users = context.Users
                        .Where(u => userList.Contains(u.Username))
                        .ToList();

                    newPost.TaggedUsers = users;
                }
            }

            return newPost;
        }

        /*<Friendship Approved="true">
    <FriendsSince>2012-05-30T09:36:07</FriendsSince>
    <FirstUser>
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
    </FirstUser>
    <SecondUser>
      <Username>Gosho</Username>
      <FirstName>Gosho</FirstName>
      <LastName>Goshov</LastName>
      <RegisteredOn>2009-07-20T19:07:12</RegisteredOn>
      <Images>
        <Image>
          <ImageUrl>http://somesite.com/SeaFeetPic</ImageUrl>
          <FileExtension>png</FileExtension>
        </Image>
        <Image>
          <ImageUrl>http://somesite.com/MyFoodShkembe</ImageUrl>
          <FileExtension>png</FileExtension>
        </Image>
      </Images>
    </SecondUser>
    <Messages>
      <Message>
        <Author>Pesho</Author>
        <Content>Sha odim li na hija?</Content>
        <SentOn>2015-10-21T11:03:27</SentOn>
        <SeenOn>2015-10-21T11:03:50</SeenOn>
      </Message>
      <Message>
        <Author>Gosho</Author>
        <Content>Epa noo qsno!</Content>
        <SentOn>2015-10-21T11:03:53</SentOn>
        <SeenOn>2015-10-21T11:04:01</SeenOn>
      </Message>
      <Message>
        <Author>Pesho</Author>
        <Content>Idealka vzimam domasharkata</Content>
        <SentOn>2015-10-21T11:04:27</SentOn>
        <SeenOn>2015-10-21T11:03:50</SeenOn>
      </Message>
    </Messages>
  </Friendship>*/
        public static Friendship CreateFriendship(this XmlReader reader, SocialNetworkContext context)
        {
            var newFriendship = new Friendship();

            var isFriendsSince = false;
            var isFirstUser = false;
            var isSecondUser = false;
            var isMessage = false;

            while (reader.Read())
            {
                var elementName = reader.Name;

                if (elementName == "Friendship")
                {
                    break;
                }
                else if (elementName == "FriendsSince")
                {
                    isFriendsSince = !isFriendsSince;
                }
                else if (elementName == "FirstUser")
                {
                    isFirstUser = !isFirstUser;
                }
                else if (elementName == "SecondUser")
                {
                    isSecondUser = !isSecondUser;
                }
                else if (elementName == "Message")
                {
                    isMessage = !isMessage;
                }
                else if (isFriendsSince)
                {
                    newFriendship.FriendsSince = DateTime.Parse(reader.Value);
                }
                else if (isFirstUser)
                {
                    //newFriendship.UserA = ? 
                }
                else if (isSecondUser)
                {
                    //newFriendship.UserB = ?
                }
                else if (isMessage)
                {
                    //var message = ? 
                    //newFriendship.Messages.Add(?);
                }
            }

            return newFriendship;
        }
    }
}
