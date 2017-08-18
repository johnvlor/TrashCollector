namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserForeignKey1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Customers", "UserID");
            RenameColumn(table: "dbo.Customers", name: "ApplicationUser_Id", newName: "UserID");
            AlterColumn("dbo.Customers", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", new[] { "UserID" });
            AlterColumn("dbo.Customers", "UserID", c => c.String());
            RenameColumn(table: "dbo.Customers", name: "UserID", newName: "ApplicationUser_Id");
            AddColumn("dbo.Customers", "UserID", c => c.String());
            CreateIndex("dbo.Customers", "ApplicationUser_Id");
        }
    }
}
