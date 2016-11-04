namespace SqlServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class creation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        FromUserId = c.Int(nullable: false),
                        InboxId = c.Int(nullable: false),
                        OutboxId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inboxes", t => t.InboxId, cascadeDelete: true)
                .ForeignKey("dbo.Outboxes", t => t.OutboxId, cascadeDelete: true)
                .Index(t => t.InboxId)
                .Index(t => t.OutboxId);
            
            CreateTable(
                "dbo.Inboxes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        InboxId = c.Int(nullable: false),
                        OutboxId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Outboxes",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inboxes", "Id", "dbo.Users");
            DropForeignKey("dbo.Outboxes", "Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "OutboxId", "dbo.Outboxes");
            DropForeignKey("dbo.Messages", "InboxId", "dbo.Inboxes");
            DropIndex("dbo.Outboxes", new[] { "Id" });
            DropIndex("dbo.Inboxes", new[] { "Id" });
            DropIndex("dbo.Messages", new[] { "OutboxId" });
            DropIndex("dbo.Messages", new[] { "InboxId" });
            DropTable("dbo.Outboxes");
            DropTable("dbo.Users");
            DropTable("dbo.Inboxes");
            DropTable("dbo.Messages");
        }
    }
}
