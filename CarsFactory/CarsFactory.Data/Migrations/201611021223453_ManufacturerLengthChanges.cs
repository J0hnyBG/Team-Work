namespace CarsFactory.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ManufacturerLengthChanges : DbMigration
    {
        public override void Up()
        {
            this.DropIndex("dbo.Manufacturers", new[] { "Name" });
            this.AlterColumn("dbo.Manufacturers", "Name", c => c.String(nullable: false, maxLength: 50));
            this.CreateIndex("dbo.Manufacturers", "Name", unique: true);
        }
        
        public override void Down()
        {
            this.DropIndex("dbo.Manufacturers", new[] { "Name" });
            this.AlterColumn("dbo.Manufacturers", "Name", c => c.String(nullable: false, maxLength: 15));
            this.CreateIndex("dbo.Manufacturers", "Name", unique: true);
        }
    }
}
