namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountTypeForeignkeyToWorker : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Workers", "AccountTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Workers", "AccountTypeID");
            AddForeignKey("dbo.Workers", "AccountTypeID", "dbo.AccountTypes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workers", "AccountTypeID", "dbo.AccountTypes");
            DropIndex("dbo.Workers", new[] { "AccountTypeID" });
            DropColumn("dbo.Workers", "AccountTypeID");
        }
    }
}
