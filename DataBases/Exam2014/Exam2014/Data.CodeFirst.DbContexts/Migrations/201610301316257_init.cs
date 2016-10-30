namespace Data.CodeFirst.DbContexts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false, maxLength: 11),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Year = c.Int(nullable: false),
                        TransmissionType = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                        DealerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dealers", t => t.DealerId, cascadeDelete: true)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .Index(t => t.ManufacturerId)
                .Index(t => t.DealerId);
            
            CreateTable(
                "dbo.Dealers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Cityid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.Cityid, cascadeDelete: true)
                .Index(t => t.Cityid);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Cars", "DealerId", "dbo.Dealers");
            DropForeignKey("dbo.Dealers", "Cityid", "dbo.Cities");
            DropIndex("dbo.Manufacturers", new[] { "Name" });
            DropIndex("dbo.Cities", new[] { "Name" });
            DropIndex("dbo.Dealers", new[] { "Cityid" });
            DropIndex("dbo.Cars", new[] { "DealerId" });
            DropIndex("dbo.Cars", new[] { "ManufacturerId" });
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Cities");
            DropTable("dbo.Dealers");
            DropTable("dbo.Cars");
        }
    }
}
