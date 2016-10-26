namespace Dealership.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PlatformType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Platforms", "PlatformType", c => c.Int(nullable: false));
            DropColumn("dbo.Platforms", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Platforms", "Name", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Platforms", "PlatformType");
        }
    }
}
