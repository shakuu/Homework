namespace ExamPrep.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class age : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SampleModels", "DateJoined", c => c.DateTime(nullable: false));
            AddColumn("dbo.SampleModels", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SampleModels", "Age");
            DropColumn("dbo.SampleModels", "DateJoined");
        }
    }
}
