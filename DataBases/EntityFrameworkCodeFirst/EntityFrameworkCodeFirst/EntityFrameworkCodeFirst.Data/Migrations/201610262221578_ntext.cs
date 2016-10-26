namespace EntityFrameworkCodeFirst.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ntext : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CourseMaterials", "Url", c => c.String(maxLength: 200));
            AlterColumn("dbo.Courses", "Description", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Description", c => c.String());
            AlterColumn("dbo.CourseMaterials", "Url", c => c.String());
        }
    }
}
