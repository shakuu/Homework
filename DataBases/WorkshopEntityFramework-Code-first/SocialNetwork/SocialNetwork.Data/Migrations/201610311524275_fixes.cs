namespace SocialNetwork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Messages", "Friendship_Id", "dbo.Friendships");
            DropIndex("dbo.Messages", new[] { "Friendship_Id" });
            RenameColumn(table: "dbo.Messages", name: "Friendship_Id", newName: "FriendshipId");
            AlterColumn("dbo.Messages", "FriendshipId", c => c.Int(nullable: false));
            CreateIndex("dbo.Friendships", "Approved");
            CreateIndex("dbo.Messages", "FriendshipId");
            AddForeignKey("dbo.Messages", "FriendshipId", "dbo.Friendships", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "FriendshipId", "dbo.Friendships");
            DropIndex("dbo.Messages", new[] { "FriendshipId" });
            DropIndex("dbo.Friendships", new[] { "Approved" });
            AlterColumn("dbo.Messages", "FriendshipId", c => c.Int());
            RenameColumn(table: "dbo.Messages", name: "FriendshipId", newName: "Friendship_Id");
            CreateIndex("dbo.Messages", "Friendship_Id");
            AddForeignKey("dbo.Messages", "Friendship_Id", "dbo.Friendships", "Id");
        }
    }
}
