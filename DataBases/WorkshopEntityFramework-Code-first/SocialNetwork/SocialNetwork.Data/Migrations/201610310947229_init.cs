namespace SocialNetwork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friendships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Approved = c.Boolean(nullable: false),
                        FriendsSince = c.DateTime(nullable: false),
                        UserA_Id = c.Int(),
                        UserB_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserA_Id)
                .ForeignKey("dbo.Users", t => t.UserB_Id)
                .Index(t => t.UserA_Id)
                .Index(t => t.UserB_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        SentOn = c.DateTime(nullable: false),
                        SeenOn = c.DateTime(),
                        Author_Id = c.Int(),
                        Friendship_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .ForeignKey("dbo.Friendships", t => t.Friendship_Id)
                .Index(t => t.SentOn)
                .Index(t => t.Author_Id)
                .Index(t => t.Friendship_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        RegisteredOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(nullable: false),
                        FileExtension = c.String(nullable: false, maxLength: 4),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, storeType: "ntext"),
                        PostedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostUsers",
                c => new
                    {
                        Post_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Post_Id, t.User_Id })
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Post_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friendships", "UserB_Id", "dbo.Users");
            DropForeignKey("dbo.Friendships", "UserA_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "Friendship_Id", "dbo.Friendships");
            DropForeignKey("dbo.PostUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.PostUsers", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Messages", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.Images", "User_Id", "dbo.Users");
            DropIndex("dbo.PostUsers", new[] { "User_Id" });
            DropIndex("dbo.PostUsers", new[] { "Post_Id" });
            DropIndex("dbo.Images", new[] { "User_Id" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Messages", new[] { "Friendship_Id" });
            DropIndex("dbo.Messages", new[] { "Author_Id" });
            DropIndex("dbo.Messages", new[] { "SentOn" });
            DropIndex("dbo.Friendships", new[] { "UserB_Id" });
            DropIndex("dbo.Friendships", new[] { "UserA_Id" });
            DropTable("dbo.PostUsers");
            DropTable("dbo.Posts");
            DropTable("dbo.Images");
            DropTable("dbo.Users");
            DropTable("dbo.Messages");
            DropTable("dbo.Friendships");
        }
    }
}
