namespace Dealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false, maxLength: 50),
                        Year = c.DateTime(nullable: false),
                        Fuel = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, storeType: "money"),
                        DealerId = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dealers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Town = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Engines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fuel = c.Int(nullable: false),
                        HorsePower = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Year = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Platforms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        NumberOfDoors = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Platforms");
            DropTable("dbo.Models");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Engines");
            DropTable("dbo.Dealers");
            DropTable("dbo.Cars");
        }
    }
}
