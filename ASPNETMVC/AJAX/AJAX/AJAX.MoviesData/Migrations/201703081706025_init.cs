namespace AJAX.MoviesData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                        Director = c.String(),
                        Year = c.Int(nullable: false),
                        LeadingMaleRole = c.String(),
                        LeadingFemaleRole = c.String(),
                        LeadingMaleRoleAge = c.Int(nullable: false),
                        LeadingFemaleRoleAge = c.Int(nullable: false),
                        Studio = c.String(),
                        StudioAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
