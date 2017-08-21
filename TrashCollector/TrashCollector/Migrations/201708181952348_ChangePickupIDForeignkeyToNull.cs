namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePickupIDForeignkeyToNull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "PickupID", "dbo.Pickups");
            DropIndex("dbo.Customers", new[] { "PickupID" });
            AlterColumn("dbo.Customers", "PickupID", c => c.Int());
            CreateIndex("dbo.Customers", "PickupID");
            AddForeignKey("dbo.Customers", "PickupID", "dbo.Pickups", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "PickupID", "dbo.Pickups");
            DropIndex("dbo.Customers", new[] { "PickupID" });
            AlterColumn("dbo.Customers", "PickupID", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "PickupID");
            AddForeignKey("dbo.Customers", "PickupID", "dbo.Pickups", "ID", cascadeDelete: true);
        }
    }
}
