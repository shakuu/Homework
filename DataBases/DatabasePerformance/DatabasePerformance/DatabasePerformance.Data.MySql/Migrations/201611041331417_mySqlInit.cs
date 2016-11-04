namespace DatabasePerformance.Data.MySql.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mySqlInit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MySqlModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(unicode: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MySqlModels");
        }
    }
}
