namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRoleTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.Workers", "RoleID", "dbo.Roles");
            DropIndex("dbo.Customers", new[] { "RoleID" });
            DropIndex("dbo.Workers", new[] { "RoleID" });
            DropColumn("dbo.Customers", "RoleID");
            DropColumn("dbo.Workers", "RoleID");
            DropTable("dbo.Roles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleTypes = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Workers", "RoleID", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "RoleID", c => c.Int(nullable: false));
            CreateIndex("dbo.Workers", "RoleID");
            CreateIndex("dbo.Customers", "RoleID");
            AddForeignKey("dbo.Workers", "RoleID", "dbo.Roles", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "RoleID", "dbo.Roles", "ID", cascadeDelete: true);
        }
    }
}
