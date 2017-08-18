namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBillingForeginkeyToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BillingID", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "BillingID");
            AddForeignKey("dbo.Customers", "BillingID", "dbo.Billings", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "BillingID", "dbo.Billings");
            DropIndex("dbo.Customers", new[] { "BillingID" });
            DropColumn("dbo.Customers", "BillingID");
        }
    }
}
