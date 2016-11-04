namespace DatabasePerformance.Data.MySql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keys : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MySqlModels",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Text = c.String(unicode: false),
                    })
                .PrimaryKey(t => new { t.Id, t.Date });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MySqlModels");
        }
    }
}
