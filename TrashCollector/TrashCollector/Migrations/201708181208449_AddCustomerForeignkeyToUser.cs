namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerForeignkeyToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "CustomerID");
            AddForeignKey("dbo.AspNetUsers", "CustomerID", "dbo.Customers", "ID", cascadeDelete: true);
            DropColumn("dbo.Customers", "Phone");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Phone", c => c.String());
            DropForeignKey("dbo.AspNetUsers", "CustomerID", "dbo.Customers");
            DropIndex("dbo.AspNetUsers", new[] { "CustomerID" });
            DropColumn("dbo.AspNetUsers", "CustomerID");
        }
    }
}
