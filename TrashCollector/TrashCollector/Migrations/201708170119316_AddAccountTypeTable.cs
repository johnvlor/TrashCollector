namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountTypeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Customers", "AccountTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "AccountTypeID");
            AddForeignKey("dbo.Customers", "AccountTypeID", "dbo.AccountTypes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "AccountTypeID", "dbo.AccountTypes");
            DropIndex("dbo.Customers", new[] { "AccountTypeID" });
            DropColumn("dbo.Customers", "AccountTypeID");
            DropTable("dbo.AccountTypes");
        }
    }
}
