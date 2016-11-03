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
                        Text = c.String(storeType: "ntext"),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Date);
            
            CreateTable(
                "dbo.ModelWithoutIndexes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(storeType: "ntext"),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.ModelWithIndexes", new[] { "Date" });
            DropTable("dbo.ModelWithoutIndexes");
            DropTable("dbo.ModelWithIndexes");
        }
    }
}
