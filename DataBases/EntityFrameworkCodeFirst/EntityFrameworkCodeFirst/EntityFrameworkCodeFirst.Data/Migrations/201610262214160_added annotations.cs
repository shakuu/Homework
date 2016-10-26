namespace EntityFrameworkCodeFirst.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedannotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Students", "Number", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Students", new[] { "Number" });
            AlterColumn("dbo.Students", "Name", c => c.String());
            AlterColumn("dbo.Courses", "Name", c => c.String());
        }
    }
}
