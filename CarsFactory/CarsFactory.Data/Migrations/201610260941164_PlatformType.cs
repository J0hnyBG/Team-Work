namespace Dealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlatformType : DbMigration
    {
        public override void Up()
        {
            this.AddColumn("dbo.Platforms", "PlatformType", c => c.Int(nullable: false));
            this.DropColumn("dbo.Platforms", "Name");
        }
        
        public override void Down()
        {
            this.AddColumn("dbo.Platforms", "Name", c => c.String(nullable: false, maxLength: 50));
            this.DropColumn("dbo.Platforms", "PlatformType");
        }
    }
}
