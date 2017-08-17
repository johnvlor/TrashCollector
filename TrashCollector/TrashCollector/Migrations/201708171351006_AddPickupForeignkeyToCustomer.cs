namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPickupForeignkeyToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PickupID", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "PickupID");
            AddForeignKey("dbo.Customers", "PickupID", "dbo.Pickups", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "PickupID", "dbo.Pickups");
            DropIndex("dbo.Customers", new[] { "PickupID" });
            DropColumn("dbo.Customers", "PickupID");
        }
    }
}
