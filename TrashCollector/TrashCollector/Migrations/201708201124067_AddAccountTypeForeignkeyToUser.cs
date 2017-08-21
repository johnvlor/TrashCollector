namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountTypeForeignkeyToUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "WorkerID", "dbo.Workers");
            DropIndex("dbo.AspNetUsers", new[] { "WorkerID" });
            AddColumn("dbo.AspNetUsers", "AccountTypeID", c => c.Int(nullable: false));
            AddColumn("dbo.Workers", "UserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "AccountTypeID");
            CreateIndex("dbo.Workers", "UserID");
            AddForeignKey("dbo.AspNetUsers", "AccountTypeID", "dbo.AccountTypes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Workers", "UserID", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.AspNetUsers", "WorkerID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "WorkerID", c => c.Int());
            DropForeignKey("dbo.Workers", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "AccountTypeID", "dbo.AccountTypes");
            DropIndex("dbo.Workers", new[] { "UserID" });
            DropIndex("dbo.AspNetUsers", new[] { "AccountTypeID" });
            DropColumn("dbo.Workers", "UserID");
            DropColumn("dbo.AspNetUsers", "AccountTypeID");
            CreateIndex("dbo.AspNetUsers", "WorkerID");
            AddForeignKey("dbo.AspNetUsers", "WorkerID", "dbo.Workers", "ID");
        }
    }
}
