namespace Dealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Current : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "ModelId", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "EngineId", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "PlatformId", c => c.Int(nullable: false));
            DropColumn("dbo.Cars", "Model");
            DropColumn("dbo.Cars", "Fuel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "Fuel", c => c.Int(nullable: false));
            AddColumn("dbo.Cars", "Model", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Cars", "PlatformId");
            DropColumn("dbo.Cars", "EngineId");
            DropColumn("dbo.Cars", "ModelId");
        }
    }
}
