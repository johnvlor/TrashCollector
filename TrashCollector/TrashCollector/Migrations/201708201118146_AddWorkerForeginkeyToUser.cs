namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWorkerForeginkeyToUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workers", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Workers", new[] { "UserID" });
            AddColumn("dbo.AspNetUsers", "WorkerID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "WorkerID");
            AddForeignKey("dbo.AspNetUsers", "WorkerID", "dbo.Workers", "ID");
            DropColumn("dbo.Workers", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workers", "UserID", c => c.String(maxLength: 128));
            DropForeignKey("dbo.AspNetUsers", "WorkerID", "dbo.Workers");
            DropIndex("dbo.AspNetUsers", new[] { "WorkerID" });
            DropColumn("dbo.AspNetUsers", "WorkerID");
            CreateIndex("dbo.Workers", "UserID");
            AddForeignKey("dbo.Workers", "UserID", "dbo.AspNetUsers", "Id");
        }
    }
}
