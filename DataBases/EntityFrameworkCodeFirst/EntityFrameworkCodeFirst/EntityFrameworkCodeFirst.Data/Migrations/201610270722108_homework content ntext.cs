namespace EntityFrameworkCodeFirst.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class homeworkcontentntext : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Students", new[] { "Number" });
            AddColumn("dbo.Students", "StudentNumber", c => c.String(maxLength: 5));
            AlterColumn("dbo.Homework", "Content", c => c.String(storeType: "ntext"));
            CreateIndex("dbo.Students", "StudentNumber", unique: true);
            DropColumn("dbo.Students", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Number", c => c.Int(nullable: false));
            DropIndex("dbo.Students", new[] { "StudentNumber" });
            AlterColumn("dbo.Homework", "Content", c => c.String());
            DropColumn("dbo.Students", "StudentNumber");
            CreateIndex("dbo.Students", "Number", unique: true);
        }
    }
}
