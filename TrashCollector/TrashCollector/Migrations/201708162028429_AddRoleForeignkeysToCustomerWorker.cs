namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoleForeignkeysToCustomerWorker : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "RoleID", c => c.Int(nullable: false));
            AddColumn("dbo.Workers", "RoleID", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "RoleID");
            CreateIndex("dbo.Workers", "RoleID");
            AddForeignKey("dbo.Customers", "RoleID", "dbo.Roles", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Workers", "RoleID", "dbo.Roles", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workers", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Customers", "RoleID", "dbo.Roles");
            DropIndex("dbo.Workers", new[] { "RoleID" });
            DropIndex("dbo.Customers", new[] { "RoleID" });
            DropColumn("dbo.Workers", "RoleID");
            DropColumn("dbo.Customers", "RoleID");
        }
    }
}
