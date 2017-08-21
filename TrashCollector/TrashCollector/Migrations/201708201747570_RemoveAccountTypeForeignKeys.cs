namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAccountTypeForeignKeys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "AccountTypeID", "dbo.AccountTypes");
            DropForeignKey("dbo.Workers", "AccountTypeID", "dbo.AccountTypes");
            DropIndex("dbo.Customers", new[] { "AccountTypeID" });
            DropIndex("dbo.Workers", new[] { "AccountTypeID" });
            DropColumn("dbo.Customers", "AccountTypeID");
            DropColumn("dbo.Workers", "AccountTypeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workers", "AccountTypeID", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "AccountTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Workers", "AccountTypeID");
            CreateIndex("dbo.Customers", "AccountTypeID");
            AddForeignKey("dbo.Workers", "AccountTypeID", "dbo.AccountTypes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Customers", "AccountTypeID", "dbo.AccountTypes", "ID", cascadeDelete: true);
        }
    }
}
