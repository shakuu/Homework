namespace DatabasePerformance.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModelWithIndexes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(maxLength: 4000),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Date);
            
            CreateTable(
                "dbo.ModelWithoutIndexes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(maxLength: 4000),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModelWithTwoIndexes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(maxLength: 4000),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Text)
                .Index(t => t.Date);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ModelWithTwoIndexes", new[] { "Date" });
            DropIndex("dbo.ModelWithTwoIndexes", new[] { "Text" });
            DropIndex("dbo.ModelWithIndexes", new[] { "Date" });
            DropTable("dbo.ModelWithTwoIndexes");
            DropTable("dbo.ModelWithoutIndexes");
            DropTable("dbo.ModelWithIndexes");
        }
    }
}
