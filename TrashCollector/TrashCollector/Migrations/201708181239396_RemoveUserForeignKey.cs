namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUserForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "CustomerID", "dbo.Customers");
            DropIndex("dbo.AspNetUsers", new[] { "CustomerID" });
            DropColumn("dbo.AspNetUsers", "CustomerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "CustomerID");
            AddForeignKey("dbo.AspNetUsers", "CustomerID", "dbo.Customers", "ID", cascadeDelete: true);
        }
    }
}
