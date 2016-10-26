namespace Dealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Current : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.Cars", "ModelId", c => c.Int(nullable: false));
            this.AddColumn("dbo.Cars", "EngineId", c => c.Int(nullable: false));
            this.AddColumn("dbo.Cars", "PlatformId", c => c.Int(nullable: false));
            this.DropColumn("dbo.Cars", "Model");
            this.DropColumn("dbo.Cars", "Fuel");
        }
        
        public override void Down()
        {
            this.AddColumn("dbo.Cars", "Fuel", c => c.Int(nullable: false));
            this.AddColumn("dbo.Cars", "Model", c => c.String(nullable: false, maxLength: 50));
            this.DropColumn("dbo.Cars", "PlatformId");
            this.DropColumn("dbo.Cars", "EngineId");
            this.DropColumn("dbo.Cars", "ModelId");
        }
    }
}
